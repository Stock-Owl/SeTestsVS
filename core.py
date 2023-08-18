from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.chrome.options import Options as ChromeOptions
# from selenium.webdriver.chrome.service import Service as ChromeService
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from selenium.webdriver.firefox.options import Options as FirefoxOptions
# from selenium.webdriver.firefox.service import Service as FirefoxService
from selenium.webdriver.remote.webelement import WebElement
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions
from selenium.common.exceptions import JavascriptException as SeJSException

from support import Support

from traceback import format_exc, format_stack

from multiprocessing import Process, Array, Value
from ctypes import c_char_p as cstring
from copy import copy

# V.1.1.0
#                                                                               22 / 25 + 1
# TODO: Kitalálni, hogy vannak az argumentumok                                  ✅  1
# TODO: Megszerelni a random useless conversionöket a JSON-ből                  ✅  2
# TODO: Relative locators                                                       ❌  NAH FUCK that shit
# TODO: JSON so get elements gets passed                                        ✅  3
# TODO: JS.Log setup    I.P.                                                    ✅  4
# TODO: Check the JS.log file if it's empty, only write if and only if empty    ✅  5
# TODO: New action: JS execution on browser console                             ✅  6
# TODO: fix JS_log so it can use the existing driver                            ✅  7
# TODO: Get two independent processes with MP.
# Detect if one has terminated (it changes a shared variable to true/false
# on termination) And then stop the execution of the other one.
# Essentially, pipe without pipe bc pipe bulk ||                                ✅  8
# TODO: make a saparate function for logging JS
# to the JS console in the GUI (on request)                                     ✅  9
# TODO: rearrange JSON, so "options" only conatins browser options
# or  make a new object for that since there are operation-level
# varibales that must be accessed and passed                                    ✅  10
# TODO: make a function that returns a default json object and filter
# if there are differences                                                      ✅  11
# TODO: implement browser naviagtion funcitons and                              ✅  12
# TODO: Units and binding                                                       ✅  13
# TODO: Beautify logging messages                                               ✅  14
# TODO: Implement breaks                                                        ✅  15
# TODO: IF the logging is ready, try to use a decorator insted of the static    ❓  + 1
# TODO: Finish wait_for implementation                                          ✅  16
# TODO: AutoLogJS needs to be patched so that it writes the logs
# even if the driver exits while it tries to write into the intermediate file   ✅  17
# TODO: Fix LogJS so that it checks for log arg type and switches               ✅  18
# TODO: add a final append to tlogs after RunDrvier has exited                  ✅  19
# TODO: add backups                                                             ✅  20
# TODO: multiprocessing funny (O = O(n)/2)                                      ✅  21
# TODO: FIrefoxDriver typecheck in CheckDriverExists so it won't cry abt it     ✅  22
# TODO: add test names to JSON and combined logs                                ❌  23
# TODO: add request shit for drivers. Seleniumwire!!! Needs to be implemented!  ❌  24
# TODO: time data collection, bounds etc.                                       ❌  25

class Core:
    default_driver_options_dict_: dict = \
    {
        "page_load_strategy": "normal",
        "accept_insecure_certs": False,
        "timeout":
        {
            "type": "pageLoad",
            "value": 300000
        },
        "unhandled_prompt_behavior": "dismiss and notify",
        "keep_browser_open": True,
        "chrome_arguments": [],
        "firefox_arguments": []
    }

    # returns the default options
    def DefaultOptions() -> tuple[ChromeOptions, FirefoxOptions]:
        defaults = copy(Core.default_driver_options_dict_)
        chrome = ChromeOptions()
        firefox = FirefoxOptions()

        chrome.page_load_strategy = defaults["page_load_strategy"]
        firefox.page_load_strategy = defaults["page_load_strategy"]

        chrome.accept_insecure_certs = defaults["accept_insecure_certs"]
        firefox.accept_insecure_certs = defaults["accept_insecure_certs"]

        chrome.timeouts = {defaults["timeout"]["type"]: defaults["timeout"]["value"]}
        firefox.timeouts = {defaults["timeout"]["type"]: defaults["timeout"]["value"]}

        chrome.unhandled_prompt_behavior = defaults["unhandled_prompt_behavior"]
        firefox.unhandled_prompt_behavior = defaults["unhandled_prompt_behavior"]

        chrome.add_experimental_option("detach", defaults["keep_browser_open"])

        for option in defaults["chrome_arguments"]:
                chrome.add_argument(option)
        for option in defaults["firefox_arguments"]:
                firefox.add_argument(option)

        return (chrome, firefox)

    # loads options
    def LoadOptions(options: dict[str]) -> tuple[ChromeOptions, FirefoxOptions]:
        """
        Loads the options from the given dict into both a ChromeOptions and FirefoxOptions object.

        Returns a tuple[2]:
        * [0]: ChromeOptions
        * [1]: FirefoxOptions
        """

        chrome = ChromeOptions()
        firefox = FirefoxOptions()

        """
        3 types of page load startegies are available:
        * normal
        * eager
        * none
        Throws a ValueError if an unsupported page load startegy type is given.
        """
        chrome.page_load_strategy = options["page_load_strategy"]
        firefox.page_load_strategy = options["page_load_strategy"]

        """
        Accept insecure cert(ification)s is either true or false. Not case sensitive
        """
        chrome.accept_insecure_certs = options["accept_insecure_certs"]  # should be a bool
        firefox.accept_insecure_certs = options["accept_insecure_certs"]  # should be a bool

        """
        3 types of timeouts are available:
        * impilicit
        * pageLoad
        * script
        Throws a ValueError if an unsupported timeout type is given.
        The value of the timeout is the timespan [of the timteout] in MILLISECONDS (ms)
        """
        chrome.timeouts = {options["timeout"]["type"]: options["timeout"]["value"]}
        firefox.timeouts = {options["timeout"]["type"]: options["timeout"]["value"]}

        """
        5 types of behaviors are available:
        * dismiss
        * accept
        * dismiss and notify
        * accept and notify
        * ignore
        Throws a ValueError if an unsupported behavior type is given.
        """
        chrome.unhandled_prompt_behavior = options["unhandled_prompt_behavior"]            
        firefox.unhandled_prompt_behavior = options["unhandled_prompt_behavior"]            

        # sets the keep browser open argument
        if options["keep_browser_open"] != "":
            chrome.add_experimental_option("detach", options["keep_browser_open"])

        # passes the browser arguments individually
        for option in options["chrome_arguments"]:
            chrome.add_argument(option)
        for option in options["firefox_arguments"]:
            firefox.add_argument(option)

        return (chrome, firefox)

    # should be preloaded JSON ergo dictionary
    def CreateDriverProcesses(json: dict[str], shared_log_size: int = 16) -> list[Process]:
        browsers: list[str] = []
        for browser in json['browsers']:
            browsers.append(browser.lower())

        driver_options: dict = json["driver_options"]

        if driver_options != Core.default_driver_options_dict_:
            browser_options: tuple[ChromeOptions, FirefoxOptions] = Core.LoadOptions(driver_options)
        
        else:
            browser_options: tuple[ChromeOptions, FirefoxOptions] = Core.DefaultOptions()

        units = json["units"]
        options: dict = json["options"]
        parent_log_path = options["parent_log_path"]
        log_js_args = options["log_JS"]
        terminal_mode = options["terminal_mode"]
        keep_browser_open = json["driver_options"]["keep_browser_open"]

        processes: list[Process] = []
        if "chrome" in browsers:
            # we will probably never need more than 16 (on log's size is 4, therefore 4 * 16 = 64)
            s_chrome = Array(cstring, shared_log_size * 4)
            s_chrome_state = Value('b', True)
            parent_log_path = options["parent_log_path"]

            chrome_kwargs: dict = \
            {
                "options": browser_options[0],
                "units": units,
                "shared_state": s_chrome_state,
                "shared_arr": s_chrome,
                "log_js_args": log_js_args,
                "parent_log_path": f"{parent_log_path}/chrome",
                "terminal_mode": terminal_mode,
                "keep_browser_open": keep_browser_open
            }
            chrome_exec = Process(target=Core.ChromeExec, kwargs=copy(chrome_kwargs))
            chrome_logger = Process(target= Core.AutoLogger, kwargs=copy(chrome_kwargs))

            processes.append(chrome_exec)
            processes.append(chrome_logger)

        if "firefox" in browsers:
            # we will probably never need more than 16 (on log's size is 4, therefore 4 * 16 = 64)
            s_firefox: Array = Array(cstring, shared_log_size * 4)
            s_firefox_state = Value('b', True)
            parent_log_path = options["parent_log_path"]

            firefox_kwargs: dict = \
            {
                "options": browser_options[1],
                "units": units,
                "shared_state": s_firefox_state,
                "shared_arr": s_firefox,
                "log_js_args": log_js_args,
                "parent_log_path": f"{parent_log_path}/firefox",
                "terminal_mode": terminal_mode,
                "keep_browser_open": keep_browser_open
            }
            firefox_exec = Process(target=Core.FirefoxExec , kwargs=copy(firefox_kwargs))
            # neither loggers are used because the geckodriver is a fucking bitch
            # firefox_logger = Process(target= Core.AutoLogger, kwargs=copy(firefox_kwargs))

            processes.append(firefox_exec)
            # processes.append(firefox_logger)

        return processes

    def ChromeExec(
        options: ChromeOptions = None,
        units: dict[str] = None,
        shared_state: Value = None,
        shared_arr: Array = None,
        terminal_mode: bool = None,
        keep_browser_open: bool = None,
        parent_log_path: str = None,
        log_js_args: dict[str] = None) -> None:

        driver = ChromeDriver(options = options)  # , service = service
        # 
        # clears the previous log files
        Support.ClearAllLogs(parent_log_path)
        
        active_bindings: list[str] = []
        failed_units: list[str] = []
        
        # deepcode ignore AttributeLoadOnNone: <Keyword arguments only set to None to make them a keyword argument. All parameters will be passed from the host funciton>
        for  uname, unit in units.items():
            try:
                backup = unit["backup_of"]

                if backup is not None:
                    # if the backup is target failed, then run as normal
                    if backup in failed_units:
                        pass
                    # if the backup target executed, skip the backup
                    else:
                        log_line = f"\'{uname}\' backup skipped because backup target unit sucessfully executed\n"
                        Support.LogProc(parent_log_path, log_line)
                        continue

                # elif, because if it's an inactive backup, it doesn't need to check for bindings
                elif uname in active_bindings:
                    log_line = f"\'{uname}\' skipped because previous unit failed\n"
                    Support.LogProc(parent_log_path, log_line)
                    continue

                actions = unit['actions']
                for aname, action in actions.items():
                    if action["break"]:
                        if terminal_mode:
                            input("press enter to resume")
                        else:

                            try:
                                with open(f"{parent_log_path}/../file.break", mode='a+', encoding='utf-8') as f:
                                    f.write(f"{uname}:{aname}\n")

                            except FileExistsError:
                                with open(f"{parent_log_path}/../file.break", mode='w', encoding='utf-8') as f:
                                    f.write(f"{uname}:{aname}\n")

                            isempty: bool = False
                            while not isempty:
                                with open(f"{parent_log_path}/../file.break", mode='r', encoding='utf-8') as f:
                                    content: str = f.read()
                                    if content == '':
                                        break

                            del isempty
                        Support.LogProc(parent_log_path, "Breakpoint")

                    match action["type"]:
                        case "goto":
                            url = action["url"]
                            Core.Goto(driver, url)
                        case "back":
                            Core.Back(driver)
                        case "forward":
                            Core.Forward(driver)
                        case "refresh":
                            Core.Refresh(driver)
                        case "js_execute":
                            commands = action["commands"]
                            Core.ExecuteJS(driver, commands, path=parent_log_path, log_JS_args=log_js_args)
                        case "wait":
                            time = action['amount']
                            Core.Wait(driver, time)
                        case "wait_for":
                            Core.WaitFor(driver, action)
                        case "click":
                            Core.ElementAction(
                                driver,
                                action = 'click',
                                locator = action['locator'],
                                value = action['value'],
                                isSingle = action['single'],
                                isDisplayed = action['displayed'],
                                isEnabled = action['enabled'],
                                isSelected = action['selected'])
                        case "send_keys":
                            Core.ElementAction(
                                driver,
                                action = 'send_keys',
                                locator = action['locator'],
                                value = action['value'],
                                keys = action['keys'],
                                isSingle = action['single'],
                                isDisplayed = action['displayed'],
                                isEnabled = action['enabled'],
                                isSelected = action['selected'])
                        case "clear":
                            Core.ElementAction(
                                driver,
                                action = 'clear',
                                locator = action['locator'],
                                value = action['value'],
                                isSingle = action['single'],
                                isDisplayed = action['displayed'],
                                isEnabled = action['enabled'],
                                isSelected = action['selected'])
                        case _:
                            action_type = action['type']
                            Support.LogProc(parent_log_path, f"Unknown action \'{action_type}\'")

                    log_line = f"[U:{uname}][A:{aname}] of type \'{action['type']}\' successfully executed"
                    Support.LogProc(parent_log_path, log_line)

            except:
                bindings = unit['bindings']
                if bindings is not None:
                    if isinstance(bindings, list):
                        for binding in bindings:
                            if isinstance(binding, str):
                                active_bindings.append(binding)
                            else:
                                # wrong element type in string list
                                Support.LogError(parent_log_path, f"Parameters in \'bindings\' must be of type str (string) not {type(binding)}")

                    elif isinstance(bindings, str):
                        active_bindings.append(bindings)

                    else:
                        # wrong elmement type for `bindings` (should be string)
                        Support.LogError(parent_log_path, f"Parameter \'bindings\' must be of type str (string) not {type(bindings)}")

                Support.LogError(parent_log_path, "❌ ERROR:\n----------------------------------------------------------------\n")
                Support.LogError(parent_log_path, f"{format_exc()}Stack:\n", time_disabled=True)

                stack = format_stack()
                # -1 to exclude this expression from stack
                for x in range(len(stack)-1):
                    stack_parts = stack[x].split('\n')
                    origin = stack_parts[0]
                    root = stack_parts[1]
                    Support.LogError(parent_log_path, f"\t[{x}] ORIGIN:\t{origin}\n\t[{x}] ROOT: {root}\t\n", time_disabled=True)
                Support.LogError(parent_log_path, "----------------------------------------------------------------\n", time_disabled=True)
                
            # this is the part that processes the brwoser logs and puts them into the shared array
            # use finally clause
            finally:
                """
                    * driver.get_log('browser')   WORKS
                    ! driver.get_log('driver') DOESN'T WORK
                    ! driver.get_log('client') DOESN'T WORK
                    ! driver.get_log('server') DOESN'T WORK
                """
                browser_logs: list[dict[str]] = driver.get_log('browser')
                # deepcode ignore NonePass: <Keyword arguments only set to None to make them a keyword argument. All parameters will be passed from the host funciton>
                Core.SharedLogDumper(logs = browser_logs, target = shared_arr, target_size = len(shared_arr))
                pass

        if keep_browser_open:
            pass

        else:
            driver.Quit()

        from datetime import date as d
        today: str = d.today().strftime("%Y-%m-%d")
        # ltlogs = long term logs
        path = f"{parent_log_path}/ltlogs/{today}.log"

        # this path doesn't need type checking, because
        # it must have been created at the start of the runtime for loop
        # and therefore it must exist
        current_log_path = f"{parent_log_path}/run.log"            
        with open(current_log_path, mode='r', encoding='utf-8') as f:
            current_log: str = f.read()

        # try to append to the log file
        try:
            with open(path, mode='r', encoding='utf-8') as f:
                f.read()
            with open(path, mode='a', encoding='utf-8') as f:
                to_write = \
                f"-------------------------------------\n\n{current_log}\n-------------------------------------\n"
                f.write(to_write)

        # if the path doesn't exist, create it and log the current date at the top of it
        except FileNotFoundError:
            with open(path, mode='w', encoding='utf-8') as f:
                to_write = \
                f"DATE: {today}\n-------------------------------------\n\n{current_log}\n-------------------------------------\n"
                f.write(to_write)

        shared_state.value = False
        return

    def FirefoxExec(
        options: FirefoxOptions = None,
        units: dict[str] = None,
        shared_state: Value = None,
        shared_arr: Array = None,
        terminal_mode: bool = None,
        keep_browser_open: bool = None,
        parent_log_path: str = None,
        log_js_args: dict[str] = None) -> None:

        driver = FirefoxDriver(options = options, keep_alive=keep_browser_open)  # , service = service
        # 
        # clears the previous log files
        Support.ClearAllLogs(parent_log_path)
                
        active_bindings: list[str] = []
        failed_units: list[str] = []

        # deepcode ignore AttributeLoadOnNone: <Keyword arguments only set to None to make them a keyword argument. All parameters will be passed from the host funciton>
        for  uname, unit in units.items():
            try:
                backup = unit["backup_of"]

                if backup is not None:
                    # if the backup is target failed, then run as normal
                    if backup in failed_units:
                        pass
                    # if the backup target executed, skip the backup
                    else:
                        log_line = f"\'{uname}\' backup skipped because target unit successfully executed\n"
                        Support.LogProc(parent_log_path, log_line)
                        continue
                
                # elif, becuase if it's an inactive backup, it doesn't need to check for bindings
                elif uname in active_bindings:
                    log_line = f"\'{uname}\' skipped because previous unit failed\n"
                    Support.LogProc(parent_log_path, log_line)
                    continue

                actions = unit['actions']
                for aname, action in actions.items():
                    if action["break"]:
                        if terminal_mode:
                            input("press enter to resume")
                        else:
                            
                            try:
                                with open(f"{parent_log_path}/../file.break", mode='a+', encoding='utf-8') as f:
                                    f.write(f"{uname}:{aname}\n")

                            except FileExistsError:
                                with open(f"{parent_log_path}/../file.break", mode='w', encoding='utf-8') as f:
                                    f.write(f"{uname}:{aname}\n")

                            isempty: bool = False
                            while not isempty:
                                with open(f"{parent_log_path}/../file.break", mode='r', encoding='utf-8') as f:
                                    content: str = f.read()
                                    if content == '':
                                        break
                            
                        Support.LogProc(parent_log_path, "Breakpoint")
                    
                    match action["type"]:
                        case "goto":
                            url = action["url"]
                            Core.Goto(driver, url)
                        case "back":
                            Core.Back(driver)
                        case "forward":
                            Core.Forward(driver)
                        case "refresh":
                            Core.Refresh(driver)
                        case "js_execute":
                            commands = action["commands"]
                            Core.ExecuteJS(driver, commands, log_JS_args=log_js_args)
                        case "wait":
                            time = action["amount"]
                            Core.Wait(driver = driver, time_ = time)
                        case "wait_for":
                            Core.WaitFor(driver, action)
                        case "click":
                            Core.ElementAction(
                            driver,
                            action = 'click',
                            locator = action['locator'],
                            value = action['value'],
                            isSingle = action['single'],
                            isDisplayed = action['displayed'],
                            isEnabled = action['enabled'],
                            isSelected = action['selected'])
                        case "send_keys":
                            Core.ElementAction(
                            driver,
                            action = 'send_keys',
                            locator = action['locator'],
                            value = action['value'],
                            keys = action['keys'],
                            isSingle = action['single'],
                            isDisplayed = action['displayed'],
                            isEnabled = action['enabled'],
                            isSelected = action['selected'])
                        case "clear":
                            Core.ElementAction(
                                driver,
                            action = 'clear',
                            locator = action['locator'],
                            value = action['value'],
                            isSingle = action['single'],
                            isDisplayed = action['displayed'],
                            isEnabled = action['enabled'],
                            isSelected = action['selected'])
                        case _:
                            action_type = action['type']
                            Support.LogProc(parent_log_path, f"Unknown action \'{action_type}\'")

                    log_line = f"[U:{uname}][A:{aname}] of type \'{action['type']}\' successfully executed"
                    Support.LogProc(parent_log_path, log_line)
            
            except:
                bindings = unit['bindings']
                if bindings is not None:
                    if isinstance(bindings, list):
                        for binding in bindings:
                            if isinstance(binding, str):
                                active_bindings.append(binding)
                            else:
                                # wrong element type in string list
                                Support.LogError(parent_log_path, f"Parameters in \'bindings\' must be of type str (string) not {type(binding)}")

                    elif isinstance(bindings, str):
                        active_bindings.append(bindings)

                    else:
                        # wrong elmement type for `bindings` (should be string)
                        Support.LogError(parent_log_path, f"Parameter \'bindings\' must be of type str (string) not {type(bindings)}")

                Support.LogError(parent_log_path, "❌ ERROR:\n----------------------------------------------------------------\n")
                Support.LogError(parent_log_path, f"{format_exc()}Stack:\n", time_disabled=True)

                stack = format_stack()
                # -1 to exclude this expression from stack
                for x in range(len(stack)-1):
                    stack_parts = stack[x].split('\n')
                    origin = stack_parts[0]
                    root = stack_parts[1]
                    Support.LogError(parent_log_path, f"\t[{x}] ORIGIN:\t{origin}\n\t[{x}] ROOT: {root}\t\n", time_disabled=True)
                Support.LogError(parent_log_path, "----------------------------------------------------------------\n", time_disabled=True)
                
            # this is the part that processes the brwoser logs and puts them into the shared array
            # use finally clause
            
            # shit is commented out because geckodriver shits itself
            """
            finally:
                
                    * driver.get_log('browser')   WORKS
                    ! driver.get_log('driver') DOESN'T WORK
                    ! driver.get_log('client') DOESN'T WORK
                    ! driver.get_log('server') DOESN'T WORK
                
                browser_logs: list[dict[str]] = driver.get_log('browser')
                # deepcode ignore NonePass: <Keyword arguments only set to None to make them a keyword argument. All parameters will be passed from the host funciton>
                Core.SharedLogDumper(logs = browser_logs, target = shared_arr, target_size = len(shared_arr))
            """

        if keep_browser_open:
            pass

        else:
            driver.Quit()

        from datetime import date as d
        today: str = d.today().strftime("%Y-%m-%d")
        # ltlogs = long term logs
        path = f"{parent_log_path}/ltlogs/{today}.log"

        # this path doesn't need type checking, because
        # it must have been created at the start of the runtime for loop
        # and therefore it must exist
        current_log_path = f"{parent_log_path}/run.log"            
        with open(current_log_path, mode='r', encoding='utf-8') as f:
            current_log: str = f.read()

        # try to append to the log file
        try:
            with open(path, mode='r', encoding='utf-8') as f:
                f.read()
            with open(path, mode='a', encoding='utf-8') as f:
                to_write = \
                f"-------------------------------------\n\n{current_log}\n-------------------------------------\n"
                f.write(to_write)

        # if the path doesn't exist, create it and log the current date at the top of it
        except FileNotFoundError:
            with open(path, mode='w', encoding='utf-8') as f:
                to_write = \
                f"DATE: {today}\n-------------------------------------\n\n{current_log}\n-------------------------------------\n"
                f.write(to_write)

        shared_state.value = False
        return

    def AutoLogger(
            shared_arr: Array = None,
            shared_state: Value = None,
            log_js_args: dict[str] = None,
            parent_log_path: str = None,
            terminal_mode: bool = None,
            **overflow) -> None:    #overflow not used
        
        """
        Appends the current JavaScript Console Logs to the end of the file.
        In return, we should get an empty file.
        An empty file means that the other process has used the console logs,
        and finished all tasks with the file. AKA the file is safe to write in.

        Args:
            * (bool) active: wether the Logging process is active or not. (does it write to the output file?)
            * (str) path: path to the log file
            * (int) refresh_rate: the amout of time (in ms) the program waits before trying to update the logs
            * (int) retry_timeout: the amout of time (in ms) the program waits before trying to write the logs (if the file was still in use)
        """
        from time import sleep

        path: str = f"{parent_log_path}/js.log"
        mimir: int | float = log_js_args['refresh_rate']    / 1000
        fuckup: int | float = log_js_args['retry_timeout']  / 1000

        assert log_js_args['active'], "auto JavaScript logging is off"
        try:
            assert Support.exists(path)
        except:
            with open(path, mode='w', encoding='utf-8') as f:
                f.write("")

        processed: list[str] = []

        while True:
            # shared vairable needs to be implemented
            # deepcode ignore AttributeLoadOnNone: <Keyword arguments only set to None to make them a keyword argument. All parameters will be passed from the host funciton>
            if not shared_state.value:
                break

            browser_logs = Core.SharedLogLoader(shared_arr)
            # inner whiles ensures that the autolog will not exit until all the logs are processed
            # it only breaks the inner loops after the logs are processed and it didn't fuck up
            if terminal_mode:
                while True:
                    with open(path, mode = 'a+', encoding = 'utf-8') as f:
                        for i in range(len(browser_logs)):
                            log = browser_logs[i]
                            if log in processed:
                                continue
                            # The reason it's processed with {i} and printed as such
                            # is that no identical logs can exist in `processed`
                            log_line = \
                            f"{i} ❗ JavaScript:\n{log['source']} — {log['level']}:\n{log['message']}\n\t{log['timestamp']}\n#\n"
                            f.write(log_line)
                            Support.LogAll(parent_log_path, log_line)
                            processed.append(log_line)
                    break
                sleep(mimir)

            else:
                while True:
                    with open(path, mode = 'r+', encoding = 'utf-8') as f:
                        contents = f.read()
                    if contents != '':
                        sleep(fuckup)
                        continue
                    else:
                        with open(path, mode = 'a+', encoding = 'utf-8') as f:
                            for i in range(len(browser_logs)):
                                log = browser_logs[i]
                                if log in processed:
                                    continue
                                # The reason it's processed with {i} and printed as such
                                # is that no identical logs can exist in `processed`
                                log_line = \
                                f"{i} ❗ JavaScript:\n{log['source']} — {log['level']}:\n{log['message']}\n\t{log['timestamp']}\n#\n"
                                f.write(log_line)
                                Support.LogAll(path = parent_log_path, log_line = log_line)
                                processed.append(log_line)
                        break
                sleep(mimir)

    def SharedLogDumper(
        logs: list[dict] = None,
        target: Array = None,
        target_size: int = None) -> None: 

        # each log is a dictionary with 4 K-VPs inside
        target_values: list[str] = []

        # only process 
        for log in logs:
            for value in log.values():
                target_values.append(bytes(str(value), 'utf-8'))

        if len(target_values) < target_size:
            for i in range(target_size - len(target_values)):
                target_values.append(bytes("", 'utf-8'))

        target[:] = target_values

    def SharedLogLoader(root: Array = None) -> list[dict[str]]:

        logs: list = []
        keys: tuple = ("level", "message", "source", "timestamp")
        # used only to detect / eleminate empty logs
        empty_log: dict = {"level": '', "message": '', "source": '', "timestamp": ''}

        field_index = 0
        log: dict = {}
        for item in root:
            item_ = str(item).removeprefix('b\'').removesuffix('\'').removeprefix('b\"').removesuffix('\"')
            if item_ == 'None':
                continue
            if field_index == 4:
                if log == empty_log:
                    break
                logs.append(copy(log))
                field_index = 0
                log.clear()
            # need to remove the b'' bounds from the item. because when you convert `bytes` to `str` that happens (builtin, I guess) ¯\_(ツ)_/¯
            log[keys[field_index]] = item_
            field_index += 1

        return logs

    def Goto(driver: ChromeDriver | FirefoxDriver, url: str):
        Core.CheckDriverExists(driver)
        driver.get(url)

    def Back(driver: ChromeDriver | FirefoxDriver):
        Core.CheckDriverExists(driver)
        driver.back()

    def Forward(driver: ChromeDriver | FirefoxDriver):
        Core.CheckDriverExists(driver)
        driver.forward()

    def Refresh(driver: ChromeDriver | FirefoxDriver):
        Core.CheckDriverExists(driver)
        driver.refresh()

    def Wait(driver: ChromeDriver | FirefoxDriver, time_: int):
        Core.CheckDriverExists(driver)
        time = float(time_ / 1000)
        driver.implicitly_wait(time)

    def WaitFor(driver: ChromeDriver | FirefoxDriver, kwargs: dict):
        # title match       ✅
        # title contains    ✅
        # url match         ✅
        # url contains      ✅
        # alert present     ✅
        # element present   ✅
        # element visible   ✅
        # 
        timeout = kwargs['timeout']
        frequency = kwargs['frequency']
        if timeout is None:
            timeout = 1000
        if frequency is None:
            wait = WebDriverWait(driver, timeout=timeout)
        else:
            wait = WebDriverWait(driver, timeout=timeout, poll_frequency=frequency)

        raw_condition: str = kwargs['condition']
        condition = raw_condition
        condition_container: function = expected_conditions.all_of

        if raw_condition[0] == '!':
            condition = raw_condition.removeprefix('!')
            condition_container: function = expected_conditions.none_of

        match condition:
            case 'element_exists':
                locator_: str = kwargs['locator']
                value_: str = kwargs['value']
                internal_locator: tuple[str, str] = (locator_, value_)
                expected = expected_conditions.presence_of_element_located(internal_locator)
                wait.until(condition_container(expected))

            case 'element_visible':
                locator_: str = kwargs['locator']
                value_: str = kwargs['value']
                element = Core.matchElement(driver, locator = locator_, value = value_)
                expected = expected_conditions.visibility_of(element)
                wait.unitl(expected)

            case 'alert_present':
                expected = expected_conditions.alert_is_present()
                wait.until(condition_container(expected))

            case 'title_matches':
                expected = expected_conditions.title_is(kwargs['title'])
                wait.until(expected)

            case 'title_contains':
                expected = expected_conditions.title_contains(kwargs['title_sub'])
                wait.until(expected)

            case 'url_matches':
                expected = expected_conditions.url_matches(kwargs['url'])
                wait.until(expected)

            case 'url_contains':
                expected = expected_conditions.url_contains(kwargs['url_sub'])
                wait.until(expected)

            case _:
                raise ValueError(f"\'{condition}\' is not a valid condition to await")

    def ExecuteJS(
        driver: ChromeDriver | FirefoxDriver,
        commands: list[str],
        terminal_mode: bool = False,
        path_ = "./logs",
        log_JS_args: dict[str, str | list | int | bool | None] = dict( active=True, refresh_rate=1000, retry_timeout=1000)
        ) -> None:

        Core.CheckDriverExists(driver)
        for i in range(len(commands)):
            try:
                command = commands[i]
                driver.execute_script(command)
            except SeJSException as e:
                # print(f"Error: the command {command} was incorrect")
                Support.LogJS(path_, log_JS_args, e, index=0, terminal_mode=terminal_mode)

    # PART FUNCS
    def MatchElement(
            driver: ChromeDriver | FirefoxDriver,
            **action_kwargs) -> WebElement:
                   
        locator = action_kwargs["locator"]
        value = action_kwargs["value"]

        if locator is None:
            # practically impossible, but just in case
            raise ValueError("Locator must be a string, not None")
        if value is None:
            # practically impossible, but just in case
            raise ValueError("Locator must be a string, not None")
        
        match locator:
            case "css_selector":
                element =  driver.find_element(By.CSS_SELECTOR, value)
            case "xpath":
                element =  driver.find_element(By.XPATH, value)
            case _:
                raise ValueError(f"Invalid locator {locator}")
            
        isDisplayed = action_kwargs["isDisplayed"]
        if isDisplayed is not None:
            # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
            assert isDisplayed == element.is_displayed(), f"Element is{' 'if isDisplayed is False else 'not '}displayed"

        isSelected = action_kwargs["isSelected"]
        if isSelected is not None:
            # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
            assert isSelected == element.is_selected(), f"Element is{' 'if isDisplayed is False else ' not '}selected"

        isEnabled = action_kwargs["isEnabled"]
        if isEnabled is not None:
            # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
            assert isEnabled == element.is_enabled(), f"Element is{' 'if isDisplayed is False else ' not '}enabled" 

        return element
    
    def MatchElements(
            driver: ChromeDriver | FirefoxDriver,
            **action_kwargs) -> list[WebElement]:
        
        locator = action_kwargs["locator"]
        value = action_kwargs["value"]

        if locator is None:
            # practically impossible, but just in case
            raise ValueError("Locator must be a string, not None")
        
        if value is None:
            # practically impossible, but just in case
            raise ValueError("Locator must be a string, not None")
        
        match locator:
            case "css_selector":
                elements = driver.find_elements(By.CSS_SELECTOR, value)
            case "xpath":
                elements = driver.find_elements(By.XPATH, value)
            case _:
                raise ValueError(f"Invalid locator {locator}")  
                  
        for element in elements:
            isDisplayed = action_kwargs["isDisplayed"]
            if isDisplayed is not None:
                # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
                for element in elements:
                    assert isDisplayed == element.is_displayed(), f"Element is{' 'if isDisplayed is False else 'not '}displayed"

            isSelected = action_kwargs["isSelected"]
            if isSelected is not None:
                # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
                for element in elements:
                    assert isSelected == element.is_selected(), f"Element is{' 'if isDisplayed is False else ' not '}selected"

            isEnabled = action_kwargs["isEnabled"]
            if isEnabled is not None:
                # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
                for element in elements:
                    assert isEnabled == element.is_enabled(), f"Element is{' 'if isDisplayed is False else ' not '}enabled"

        return elements
      
    def ElementAction(
            driver: ChromeDriver | FirefoxDriver,
            **action_kwargs) -> WebElement | list[WebElement]:
        
        result: WebElement | list[WebElement]
        isSingle = action_kwargs["isSingle"]
        if isSingle:
            result = Core.MatchElement(driver, **action_kwargs)                
            action = action_kwargs["action"]
            match action:
                case "click":
                    result.click()
                case "send_keys":
                    keys = action_kwargs["keys"]
                    result.send_keys(keys)
                case "clear":
                    result.clear()
                case _:
                    raise ValueError("Invalid action type") 
                                   
            driver.switch_to.parent_frame()     #if there was an iframe, this goes back to the top of the frame

        elif isSingle == False:
            results = Core.MatchElements(driver, **action_kwargs)
            for result in results:                    
                action = action_kwargs["action"]
                match action:
                    case "click":
                        result.click()
                    case "send_keys":
                        keys = action_kwargs["keys"]
                        result.send_keys(keys)
                    case "clear":
                        result.clear()
                    case _:
                        raise ValueError("Invalid action type")
                                          
            driver.switch_to.parent_frame()     #if there was an iframe, this goes back to the top of the frame 

    def CheckDriverExists(driver: object, omit_exceptions: bool = True) -> None | bool | Exception:
        try:
            assert driver
        except AssertionError:
            if omit_exceptions:
                print("Shit doesn't exist mate")
                return False
            raise AssertionError("Shit doesn't exist mate")
            
        try:
            assert isinstance(driver, ChromeDriver | FirefoxDriver)
        except AssertionError:
            if omit_exceptions:
                print("Invalid fuckin' type mate")
                return False
            raise AssertionError("Invalid fuckin' type mate")
        if omit_exceptions:            
            return True
        return None
                    