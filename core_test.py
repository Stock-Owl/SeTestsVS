from selenium import webdriver
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from selenium.webdriver.firefox.options import Options as FirefoxOptions
from selenium.webdriver.firefox.service import Service as FirefoxService
from selenium.webdriver.remote.webelement import WebElement
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions
from selenium.common.exceptions import JavascriptException as SeJSException
from selenium.webdriver.support.wait import WebDriverWait

from traceback import format_exc, format_stack
from json import loads
from datetime import time
import multiprocessing as mp
class Core:
    class Firefox:

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
                "browser_arguments": []
        }

        def DefaultOptions() -> FirefoxOptions:
            from copy import copy
            defaults = copy(Core.Firefox.default_driver_options_dict_)
            options = FirefoxOptions()
            options.page_load_strategy = defaults["page_load_strategy"]
            options.accept_insecure_certs = defaults["accept_insecure_certs"]
            options.timeouts = {defaults["timeout"]["type"]: defaults["timeout"]["value"]}
            options.unhandled_prompt_behavior = defaults["unhandled_prompt_behavior"]
            options.add_experimental_option("detach", defaults["keep_browser_open"])
            for option in defaults["browser_arguments"]:
                    options.add_argument(option)
            return options
        
        def RunDriver(path: str | None = None, json_string: str | None = None) -> None:
            # loads json file or loads the string and instanciates the actions par and the 
            loaded_dict: dict
            if type(json_string) == type(path):
                log_line: str = "You either give a path to the json file or parse the json string raw, bitch.\nNOT both! Which one am I supposed to use, you expired coupon?!"
                Support.log_error("./logs", log_line)
                return None
            elif path is None:
                loaded_dict = loads(json_string)
            else:
                try:
                    with open(path, 'r', encoding='utf-8') as f:
                       loaded_dict = loads(f.read())
                except FileNotFoundError:
                    log_line: str = "Invalid path, file not found"
                    Support.log_error("./logs", log_line)
                    return None
                
            driver: FirefoxDriver
            driver_options_ =  loaded_dict["driver_options"]
            global_options = loaded_dict["options"]
            # print(loaded_dict)
            units: dict = loaded_dict["units"]

            LogJSArgs = global_options["log_JS"]
            parent_log_path = global_options["parent_log_path"]
            terminal_mode = global_options["terminal_mode"]

            # create the Firefox driver with arguments
            if driver_options_ != Core.Firefox.default_driver_options_dict_:
                service_: dict = driver_options_["service"]
                
                log_path: str = service_["log_path"]
                service_args: list[str] = service_["arguments"]
                # Not used because the Firefoxdriver is a bitch and crashes for some reason before even creating the driver...
                # Akkor, a kurva anyját (:
                service = FirefoxService(service_args = service_args, log_path = log_path)

                opts = FirefoxOptions()

                """
                3 types of page load startegies are available:
                * normal
                * eager
                * none

                Throws a ValueError if an unsupported page load startegy type is given.
                """
                opts.page_load_strategy = driver_options_["page_load_strategy"]

                """
                Accept insecure cert(ification)s is either true or false. Not case sensitive
                """
                opts.accept_insecure_certs = driver_options_["accept_insecure_certs"]  # should be a bool

                """
                3 types of timeouts are available:
                * impilicit
                * pageLoad
                * script

                Throws a ValueError if an unsupported timeout type is given.

                The value of the timeout is the timespan [of the timteout] in MILLISECONDS (ms)
                """
                opts.timeouts = {driver_options_["timeout"]["type"]: driver_options_["timeout"]["value"]}

                """
                5 types of behaviors are available:
                * dismiss
                * accept
                * dismiss and notify
                * accept and notify
                * ignore

                Throws a ValueError if an unsupported behavior type is given.
                """
                opts.unhandled_prompt_behavior = driver_options_["unhandled_prompt_behavior"]

                #if driver_options_["keep_browser_open"] != "":
                #    opts.add_experimental_option("detach", driver_options_["keep_browser_open"])

                for option in driver_options_["browser_arguments"]:
                    opts.add_argument(option)

            # create the Firefox driver (as bare bones as it gets)
            elif driver_options_ == Core.Firefox.default_driver_options_dict_:
                opts = Core.Firefox.DefaultOptions()
                # NOT used. see line 110
                # service = Core.Firefox.DefaultService()
            else:
                Support.log_error(parent_log_path, "Some shit got fucked up. But I have no clue what exactly.")
            # service commented out bc chromdriver shits itslef, ig
            driver = FirefoxDriver(options = opts)   # , service = service
            # 
            # clears the previous log filed
            Support.clear_all_logs(parent_log_path)

            active_binds: list[str] = []
            failed_units: list[str] = []
            for uname, unit in units.items():
                try:
                    if uname in active_binds:
                        log_line = f"\'{uname}\' skipped because previous unit failed\n"
                        Support.log_proc(parent_log_path, log_line)
                        continue
    
                    actions = unit['actions']
                    for aname, action in actions.items():
                        print(action)
                        if action["break"]:
                            if terminal_mode:
                                input("press enter to resume")
                            else:
                                pass   # majd ide kell egy intermediate comms file megint mint a JS-nél
                            Support.log_proc(parent_log_path, "Breakpoint")

                        match action["type"]:
                            case "goto":
                                url = action["url"]
                                Core.Firefox.goto(driver, url)
                            case "back":
                                Core.Firefox.back(driver)
                            case "forward":
                                Core.Firefox.forward(driver)
                            case "refresh":
                                Core.Firefox.refresh(driver)
                            case "js_execute":
                                commands = action["commands"]
                                Core.Firefox.execute_js(driver, commands, path=parent_log_path, log_JS_args=LogJSArgs)
                            case "wait":
                                time = action['amount']
                                Core.Firefox.wait(driver, time)
                            case "wait_for":
                                Core.Firefox.waitFor(driver, action)
                                # timeout = action['timeout']
                                # frequency = action['frequency']
                                # condition = action['condition']
                            case "click":
                                Core.Firefox.ElementAction(
                                    driver,
                                    action = 'click',
                                    locator = action['locator'],
                                    value = action['value'],
                                    isSingle = action['single'],
                                    isDisplayed = action['displayed'],
                                    isEnabled = action['enabled'],
                                    isSelected = action['selected'])
                            case "send_keys":
                                Core.Firefox.ElementAction(
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
                                Core.Firefox.ElementAction(
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
                                Support.log_proc(parent_log_path, f"Unknown action \'{action_type}\'")
                                
                        log_line = f"[U:{uname}][A:{aname}] of type \'{action['type']}\' successfully executed"
                        Support.log_proc(parent_log_path, log_line)

                except:
                    bindings = unit['bindings']
                    if bindings is not None:
                        if isinstance(bindings, list):
                            for binding in bindings:
                                if isinstance(binding, str):
                                    active_binds.append(binding)
                                else:
                                    # wrong element type in string list
                                    Support.log_error(parent_log_path, f"Parameters in \'bindings\' must be of type str (string) not {type(binding)}")
                        elif isinstance(bindings, str):
                            active_binds.append(bindings)
                        else:
                            # wrong elmement type for `bindings` (should be string)
                            Support.log_error(parent_log_path, f"Parameter \'bindings\' must be of type str (string) not {type(bindings)}")

                    Support.log_error(parent_log_path, "----------------------------------------------------------------\n")
                    Support.log_error(parent_log_path, f"{format_exc()}\nStack:\n", time_disabled=True)
                    stack = format_stack()
                    # -1 to exclude this expression from stack
                    for x in range(len(stack)-1):
                        stack_parts = stack[x].split('\n')
                        origin = stack_parts[0]
                        root = stack_parts[1]
                        Support.log_error(parent_log_path, f"\t[{x}] ORIGIN:\t{origin}\n\t[{x}] ROOT:{root}\n\n", time_disabled=True)
                    Support.log_error(parent_log_path, "----------------------------------------------------------------\n", time_disabled=True)

            #
            if driver_options_["keep_browser_open"]:
                pass
            else:
                driver.Quit()

        def goto(driver: FirefoxDriver, url: str):
            Core.checkDriverExists(driver)
            driver.get(url)

        def back(driver: FirefoxDriver):
            Core.checkDriverExists(driver)
            driver.back()

        def forward(driver: FirefoxDriver):
            Core.checkDriverExists(driver)
            driver.forward()

        def refresh(driver: FirefoxDriver):
            Core.checkDriverExists(driver)
            driver.refresh()

        def wait(driver: FirefoxDriver, time_: int):
            Core.checkDriverExists(driver)
            time = float(time_ / 1000)
            driver.implicitly_wait(time)
        # NEEDS WORK
        def waitFor(driver: FirefoxDriver, kwargs: dict):
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

            condition = kwargs['condition']
            match condition:
                case 'element_exists':
                    locator_: str = kwargs['locator']
                    value_: str = kwargs['value']
                    internal_locator: tuple[str, str] = (locator_, value_)
                    wait.until(expected_conditions.presence_of_element_located(internal_locator))
                case 'element_visible':
                    locator_: str = kwargs['locator']
                    value_: str = kwargs['value']
                    element = Core.Firefox.matchElement(driver, locator = locator_, value = value_)
                    # always waits until the visibility is true
                    wait.unitl(expected_conditions.visibility_of(element))
                case 'alert_present':
                    wait.until(expected_conditions.alert_is_present())
                case 'title_matches':
                    wait.until(expected_conditions.title_is(kwargs['title']))
                case 'title_contains':
                    wait.until(expected_conditions.title_contains(kwargs['title_sub']))
                case 'url_matches':
                    wait.until(expected_conditions.url_matches(kwargs['url']))
                case 'url_contains':
                    wait.until(expected_conditions.url_contains(kwargs['url_sub']))
                case _:
                    raise ValueError(f"\'{condition}\' is not a valid condition to await")
        
        # PART FUNCS

        def matchElement(driver: FirefoxDriver,
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

        def matchElements(driver: FirefoxDriver, **action_kwargs) -> list[WebElement]:

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
                driver: FirefoxDriver,
                **action_kwargs
                ) -> WebElement | list[WebElement]:

            result: WebElement | list[WebElement]

            isSingle = action_kwargs["isSingle"]

            if isSingle:
                result = Core.Firefox.matchElement(driver, **action_kwargs)
                
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
                results = Core.Firefox.matchElements(driver, **action_kwargs)
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
                    
        def execute_js(
            driver: FirefoxDriver,
            commands: list[str],
            terminal_mode: bool = False,
            path_ = "./logs",
            log_JS_args: dict[str, str | list | int | bool | None] = \
                    dict(active=True,
                         refresh_rate=1000,
                         retry_timeout=1000)
            ):

            Core.checkDriverExists(driver)
            for i in range(len(commands)):
                try:
                    command = commands[i]
                    driver.execute_script(command)
                except SeJSException as e:
                    # print(f"Error: the command {command} was incorrect")
                    Support.logJS(path_, log_JS_args, e, index=0, terminal_mode=terminal_mode)

    # quite possibly useless
    def quit_driver(driver: object):
        """
        Quits the driver AND deletes the driver from the gloabl scope.

        """
        driver.quit()
        for item in globals().items():
            if item[1] == driver:
                # print(f"match found:\n{item[1]} == {driver} => True. Deleted!")
                del globals()[item[0]]
                break
        """    
        try:
            print(driver)
        except NameError:
            print("Successfully quit and deleted")
        """

    def checkDriverExists(driver: object, omit_exceptions: bool = True) -> None | bool | Exception:
        try:
            assert driver
        except AssertionError:
            if omit_exceptions:
                print("Shit doesn't exist mate")
                return False
            raise AssertionError("Shit doesn't exist mate")
            
        try:
            assert isinstance(driver, FirefoxDriver)
        except AssertionError:
            if omit_exceptions:
                print("Invalid fuckin' type mate")
                return False
            raise AssertionError("Invalid fuckin' type mate")
        if omit_exceptions:            
            return True
        return None
                    

class Support:
    from os.path import exists

    def clear_all_logs(path_: str) -> None:
        paths: list[str] = [
            f"{path_}/run.log",
            f"{path_}/process.log",
            f"{path_}/js.log",
            f"{path_}/error.log"]
        
        for file in paths:
            with open("log.txt", mode='w', encoding='utf-8') as f:
                f.write("")

    def log_all(path_: str, log_line: str, time_disabled: bool = False) -> None:
        from datetime import datetime as dt

        path = f"{path_}/run.log"

        try:
            assert Support.exists(path)
        except AssertionError:
            with open("log.txt", mode='w', encoding='utf-8') as f:
                f.write("")

        with open("log.txt", "a", encoding="utf-8") as f:
            if not time_disabled:
                time_: str = dt.now().time().strftime("%H:%M:%S\n")
                f.write(time_)
            f.write(log_line)

    def logJS(
            path_: str,
            log_JS_args: dict[str, str | list | int | bool | None],
            log: str | SeJSException,
            terminal_mode = False,
            time_disabled: bool = False,
            index: int | None = None) -> None:
        from time import sleep
        

        path: str = f"{path_}/js.log"
        fuckup: int | float = log_JS_args['retry_timeout']  / 1000

        try:
            assert Support.exists(path)
        except FileNotFoundError:
            with open("log.txt", mode='w', encoding='utf-8') as f:
                f.write("")

        # type checking required in both terminal and normal mode
        # because exception logging requires a different log line
        if terminal_mode:
            if isinstance(log, SeJSException):
                stacktrace = "\n".join(log.stacktrace)
                with open("log.txt", 'a+', encoding='utf-8') as f:
                    if index is not None:
                        to_write = f"{index} ❗ JavaScript:\n{log.msg}\nSteack Trace:\n{stacktrace}\n"
                    else:
                        to_write = f"❗ JavaScript:\n{log.msg}\nSteack Trace:\n{stacktrace}\n"
                    f.write(to_write)
                    Support.log_all(path_, to_write, time_disabled = time_disabled)
            elif isinstance(log, str):
                with open("log.txt", mode ='a', encoding='utf-8') as f:
                    if index is not None:
                        to_write = f"{index} ❗ JavaScript:\\n{log}\n"
                    else:
                        to_write = f"❗ JavaScript:\\n{log}\n"
                    f.write(to_write)
                    Support.log_all(path_, to_write, time_disabled = time_disabled)
            else: raise ValueError("logJS takes either a string or a selenium.common.exceptions.JavascriptException as an argument")

        else:
            while True:
                with open("log.txt", mode = 'r', encoding = "utf-8") as f:
                    contents: str = f.read()
                if contents != '':
                    sleep(fuckup)
                    continue
                else:
                    if isinstance(log, SeJSException):
                        stacktrace = "\n".join(log.stacktrace)
                        if index is not None:
                            to_write: str = f"{index} ❗ JavaScript:\n{log.msg}\nSteack Trace:\n{stacktrace}\n"
                        else:
                            to_write: str = f"❗ JavaScript:\n{log.msg}\nSteack Trace:\n{stacktrace}\n"
                        with open("log.txt", mode ='a', encoding='utf-8') as f:
                            f.write(to_write)
                            Support.log_all(path_, to_write, time_disabled = time_disabled)
                        break
                    elif isinstance(log, str):
                        with open("log.txt", mode ='a', encoding='utf-8') as f:
                            to_write = f"❗ JavaScript:\\n{log}\n"
                            f.write(to_write)
                            Support.log_all(path_, to_write, time_disabled = time_disabled)
                        break
                    else: raise ValueError("logJS takes either a string or a selenium.common.exceptions.JavascriptException as an argument")
        
    def auto_logJS(
            driver: FirefoxDriver,
            path_: str,
            log_JS_args: dict[str, str | list | int | bool | None],
            terminal_mode: bool = False,
            time_disabled: bool = False) -> None:
        from time import sleep
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

        path: str = f"{path_}/js.log"
        mimir: int | float = log_JS_args['refresh_rate']    / 1000
        fuckup: int | float = log_JS_args['retry_timeout']  / 1000

        assert log_JS_args['active'], "auto JavaScript logging is off"
        try:
            assert Support.exists(path)
        except:
            with open("log.txt", mode='w', enocdintóg='utf-8') as f:
                f.write("")

        processed: list[str] = []

        while True:
            browser_logs = driver.get_log("browser")
            # shared vairable needs to be implemented

            # inner whiles ensures that the autolog will not exit until all the logs are processed
            # it only breaks the inner loops after the logs are processed and it didn't fuck up
            if terminal_mode:
                while True:
                    with open("log.txt", mode = 'a', encoding = 'utf-8') as f:
                        for i in range(len(browser_logs)):
                            log = browser_logs[i]
                            if log in processed:
                                continue
                            # The reason it's processed with {i} and printed as such
                            # is that no identical logs can exist in `processed`
                            log_line = \
                            f"{i} ❗ JavaScript:\n{log['source']} — {log['level']}:\n{log['message']}\n\t{log['timestamp']}\n#\n"
                            f.write(log_line)
                            Support.log_all(path = path_, log_line = log_line, time_disabled=time_disabled)
                            processed.append(log_line)
                    break
                sleep(mimir)

            else:
                while True:
                    with open("log.txt", mode = 'r+', encoding = 'utf-8') as f:
                        contents = f.read()
                    if contents != '':
                        sleep(fuckup)
                        continue
                    else:
                        with open("log.txt", mode = 'a', encoding = 'utf-8') as f:
                            for i in range(len(browser_logs)):
                                log = browser_logs[i]
                                if log in processed:
                                    continue
                                # The reason it's processed with {i} and printed as such
                                # is that no identical logs can exist in `processed`
                                log_line = \
                                f"{i} ❗ JavaScript:\n{log['source']} — {log['level']}:\n{log['message']}\n\t{log['timestamp']}\n#\n"
                                f.write(log_line)
                                Support.log_all(path = path_, log_line = log_line, time_disabled=time_disabled)
                                processed.append(log_line)
                        break
                sleep(mimir)

    def log_proc(path_: str, log_line: str, time_disabled: bool = False) -> None:
        
        path = f"{path_}/process.log"

        try:
            assert Support.exists(path)
        except:
            with open("log.txt", mode='w', encoding='utf-8') as f:
                f.write("")
        
        log_line = f"✅ DONE: {log_line}\n"
        with open("log.txt", mode='a+', encoding='utf-8') as f:
            f.write(log_line)
        Support.log_all(path_, log_line, time_disabled=time_disabled)

    def log_error(path_: str, log_line: str,  time_disabled: bool = False) -> None:

        path = f"{path_}/error.log"

        try:
            assert Support.exists(path)
        except:
            with open("log.txt", mode='w', encoding='utf-8') as f:
                f.write("")

        log_line = f"❌ ERROR: {log_line}\n"
        with open("log.txt", mode='a+', encoding='utf-8') as f:
            f.write(log_line)
        Support.log_all(path_, log_line, time_disabled=time_disabled)