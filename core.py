from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from seleniumwire.webdriver import Firefox as WireFirefoxDriver     # selenium-wire because that supports the HTTP request interception 
from seleniumwire.webdriver import Chrome as WireChromeDriver       # selenium-wire because that supports the HTTP request interception

from selenium.webdriver.chrome.options import Options as ChromeOptions
from selenium.webdriver.firefox.options import Options as FirefoxOptions

from support import Support
from actions import Actions
from interceptor import Interceptor

from traceback import format_exc, format_stack

from multiprocessing import Process
from copy import copy
from os import getpid

# V.1.2.0
#                                                                               25 / 27 + 1
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
# TODO: add test names to JSON and combined logs                                ✅  23
# TODO: add request shit for drivers. Seleniumwire!!! Needs to be implemented!  ❌  24
# TODO: time data collection, bounds etc.                                         GUI
# TODO: breakpoint intermediate                                                 ✅  25
# TODO: installer update                                                        ❌  26
# TODO: refactoring                                                             ✅  27

# Snyk deepcode ignores:
# file deepcode ignore AttributeLoadOnNone: <Keyword arguments only set to None to make them a keyword argument. All parameters will be passed from the host funciton>
# file deepcode ignore NonePass: <Keyword arguments only set to None to make them a keyword argument. All parameters will be passed from the host funciton>


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
    def CreateDriverProcesses(json: dict[str]) -> list[Process]:
        driver_options: dict = json["driver_options"]

        if driver_options != Core.default_driver_options_dict_:
            browser_options: tuple[ChromeOptions, FirefoxOptions] = Core.LoadOptions(driver_options)
        
        else:
            browser_options: tuple[ChromeOptions, FirefoxOptions] = Core.DefaultOptions()

        units = json["units"]
        options: dict[str] = json["options"]
        parent_log_path: str = options["parent_log_path"]
        log_js_retry_timeout: int = options["log_JS_retry_timeout"]
        keep_browser_open: bool = json["driver_options"]["keep_browser_open"]
        interceptor: bool = json["interceptor"]
        testname: str = json["name"]

        processes: list[Process] = []
        parent_log_path = options["parent_log_path"]

        chrome_kwargs: dict = \
        {
            "options": browser_options[0],
            "units": units,
            "testname": testname,
            "interceptor_active": interceptor,
            "log_js_retry_timeout": log_js_retry_timeout,
            "keep_browser_open": keep_browser_open,
            "browser": "chrome",
            "parent_log_path": f"{parent_log_path}/chrome"
        }

        chrome_exec = Process(target=Core.DriverExec, kwargs=chrome_kwargs)
        processes.append(chrome_exec)

        firefox_kwargs: dict = \
        {
            "options": browser_options[1],
            "units": units,
            "testname": testname,
            "interceptor_active": interceptor,
            "log_js_retry_timeout": log_js_retry_timeout,
            "keep_browser_open": keep_browser_open,
            "browser": "firefox",
            "parent_log_path": f"{parent_log_path}/firefox"
        }

        firefox_exec = Process(target=Core.DriverExec , kwargs=firefox_kwargs)
        processes.append(firefox_exec)

        return processes

    def DriverExec(
        browser: str = None,
        options: ChromeOptions | FirefoxOptions = None,
        units: dict[str] = None,
        testname: str = None,
        interceptor_active: bool = None,
        keep_browser_open: bool = None,
        parent_log_path: str = None,
        log_js_retry_timeout: int = None,
        **overflow) -> None:

        print(f"Driver ({browser}) PID:", getpid())
        logging_active: bool = False

        if interceptor_active:
            interceptor = Interceptor()
            
        if browser == 'chrome':
            if interceptor_active:
                driver = WireChromeDriver(options = options) # , service = service
            else:
                driver = ChromeDriver(options = options)  # , service = service
            browser_break_char = 'c'
            logging_active = True

        elif browser == 'firefox':
            if interceptor_active:
                driver = WireFirefoxDriver(options = options, keep_alive=keep_browser_open) # , service = service
            else:
                driver = FirefoxDriver(options = options, keep_alive=keep_browser_open) # , service = service
            browser_break_char = 'f'
            
        else:
            print(f"Unknown browser {browser}")
            Support.LogError(parent_log_path, f"Unknown browser {browser}")
            return None

        # clears the previous log files
        Support.ClearAllLogs(parent_log_path)
        
        active_bindings: list[str] = []
        failed_units: list[str] = []
        
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
                        try:
                            if logging_active:
                                print("logging active")
                                Support.LogBrowserJSLog(driver, parent_log_path, log_js_retry_timeout)
                                
                            print(f"breakpoint writing U{uname}\tA:{aname}")
                            with open(f"{parent_log_path}/../file.brk", mode='a+', encoding='utf-8') as f:
                                f.write(f"{browser_break_char}:{uname}:{aname}\n")

                        except FileNotFoundError:
                            print(f"breakpoint creating file U{uname}\tA:{aname}")
                            with open(f"{parent_log_path}/../file.brk", mode='w', encoding='utf-8') as f:
                                f.write(f"{browser_break_char}:{uname}:{aname}\n")

                        isempty: bool = False
                        print(f"breakpoint waiting U{uname}\tA:{aname}")
                        while not isempty:
                            with open(f"{parent_log_path}/../file.brk", mode='r', encoding='utf-8') as f:
                                content: str = f.read()
                                if content == '':
                                    break
                                else:
                                    pass

                        print(f"breakpoint finished U{uname}\tA:{aname}")

                        Support.LogProc(parent_log_path, "Breakpoint")

                    match action["type"]:
                        case "goto":
                            url = action["url"]
                            Actions.Goto(driver, url)
                        case "back":
                            Actions.Back(driver)
                        case "forward":
                            Actions.Forward(driver)
                        case "refresh":
                            Actions.Refresh(driver)
                        case "interceptor_on":
                            if interceptor_active:
                                Actions.InterceptorOn(driver, interceptor)
                            else:
                                print("Interceptor is off")
                                Support.LogProc(parent_log_path, "Interceptor is off")
                                continue
                        case "interceptor_off":
                            if interceptor_active:
                                Actions.InterceptorOff(driver)
                            else:
                                print("Interceptor is off")
                                Support.LogProc(parent_log_path, "Interceptor is off")
                                continue
                        case "interceptor_add":
                            if interceptor_active:
                                name_: str = action["name"]
                                type_: str = action["request_section"]
                                key_: str = action["key"]
                                value_: str = action["value"]
                                interceptor.Add(
                                    name_,
                                    type_,
                                    key_,
                                    value_)
                            else:
                                print("Interceptor is off")
                                Support.LogProc(parent_log_path, "Interceptor is off")
                                continue
                        case "interceptor_remove":
                            if interceptor_active:
                                name_: str = action["name"]
                                interceptor.Remove(name_)
                            else:
                                print("Interceptor is off")
                                Support.LogProc(parent_log_path, "Interceptor is off")
                                continue
                        case "js_execute":
                            commands = action["commands"]
                            Actions.ExecuteJS(driver, commands, path=parent_log_path, retry_timeout=log_js_retry_timeout)
                        case "wait":
                            time = action['amount']
                            Actions.Wait(driver, time)
                        case "wait_for":
                            Actions.WaitFor(driver, action)
                        case "switch_back":
                            Actions.SwitchBack(driver)
                        case "switch_to":
                            Actions.ElementAction(
                                driver,
                                action = 'switch_to',
                                locator = action['locator'],
                                value = action['value'],
                                isSingle = True,
                                isDisplayed = None,
                                isEnabled = None,
                                isSelected = None
                                )
                        case "click":
                            Actions.ElementAction(
                                driver,
                                action = 'click',
                                locator = action['locator'],
                                value = action['value'],
                                isSingle = action['single'],
                                isDisplayed = action['displayed'],
                                isEnabled = action['enabled'],
                                isSelected = action['selected'])
                        case "send_keys":
                            Actions.ElementAction(
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
                            Actions.ElementAction(
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

                failed_units.append(uname)
                Support.LogError(parent_log_path, f"Unit \"{uname}\"  failed")

                Support.LogError(parent_log_path, "❌ ERROR:\n----------------------------------------------------------------\n")
                Support.LogError(parent_log_path, f"{format_exc()}Stack:\n", time_disabled=True)

                stack = format_stack()
                # -1 to exclude this expression from stack
                for x in range(len(stack)-1):
                    stack_parts = stack[x].split('\n')
                    origin = stack_parts[0]
                    root = stack_parts[1]
                    Support.LogError(parent_log_path, f"\t[{x}] ORIGIN:\t{origin}\n\t[{x}] ROOT: {root}\t", time_disabled=True)
                Support.LogError(parent_log_path, "----------------------------------------------------------------\n", time_disabled=True)

        if logging_active:
            Support.LogBrowserJSLog(driver, parent_log_path, log_js_retry_timeout)

        if not keep_browser_open:
            driver.quit()

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
                f"-------------------------------------\n\n{testname}\n{current_log}\n-------------------------------------\n"
                f.write(to_write)

        # if the path doesn't exist, create it and log the current date at the top of it
        except FileNotFoundError:
            with open(path, mode='w', encoding='utf-8') as f:
                to_write = \
                f"DATE: {today}\n-------------------------------------\n\n{testname}\n{current_log}\n-------------------------------------\n"
                f.write(to_write)

        print(f"Driver ({browser}) finished")
