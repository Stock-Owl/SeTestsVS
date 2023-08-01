from selenium import webdriver
from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.chrome.options import Options as ChromeOptions
from selenium.webdriver.chrome.service import Service as ChromeService
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from selenium.webdriver.firefox.options import Options as FirefoxOptions
from selenium.webdriver.firefox.service import Service as FirefoxService
from selenium.webdriver.remote.webelement import WebElement
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions
from selenium.common.exceptions import JavascriptException as SeJSException

from datetime import time
from traceback import format_exc, format_stack
import multiprocessing as mp
from copy import copy
from json import loads
import traceback

#                                                                               12 / 14
# TODO: Kitalálni, hogy vannak az argumentumok                                  ✅  1
# TODO: Megszerelni a random useless conversionöket a JSON-ből                  ✅  2
# TODO: Relative locators                                                       ❌  3
# TODO: JSON so get elements gets passed                                        ✅  4
# TODO: JS.Log setup    I.P.                                                    ✅  5
# TODO: Check the JS.log file if it's empty, only write if and only if empty    ✅  6
# TODO: New action: JS execution on browser console                             ✅  7
# TODO: fix JS_log so it can use the existing driver                            ✅  8
# TODO: Get two independent processes with MP.
# Detect if one has terminated (it changes a shared variable to true/false
# on termination) And then stop the execution of the other one.
# Essentially, pipe without pipe bc pipe bulk ||                                ✅  9
# TODO: make a saparate function for logging JS
# to the JS console in the GUI (on request)                                     ✅  10
# TODO: rearrange JSON, so "options" only conatins browser options
# or  make a new object for that since there are operation-level
# varibales that must be accessed and passed                                    ✅  11
# TODO: make a function that returns a default json object and filter
# if there are differences                                                      ✅  12
# TODO: implement browser naviagtion funcitons and                              ✅  13
# TODO: Units and binding                                                       ❌  14

none = ""

class Core:
    class Firefox:

        default_driver_options_dict_: dict = \
        {
            "options":
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
            },
            "service":
            {
                "log_path": ".",
                "arguments": []
            }
        }

        def DefaultOptions() -> FirefoxOptions:
            content = Core.Firefox.default_driver_options_dict_
            opts = copy(content["options"])
            del content
            options = FirefoxOptions()
            options.page_load_strategy = opts["page_load_strategy"]
            options.accept_insecure_certs = opts["accept_insecure_certs"]
            options.timeouts = {opts["timeout"]["type"]: opts["timeout"]["value"]}
            options.unhandled_prompt_behavior = opts["unhandled_prompt_behavior"]
            options.add_experimental_option("detach", opts["keep_browser_open"])
            for option in opts["browser_arguments"]:
                    options.add_argument(option)
            return options
        
        def DefaultService() -> FirefoxService:
            content = Core.Firefox.default_driver_options_dict_
            serv = copy(content["service"])
            del content
            log_path: str = serv["log_path"]
            args = serv["arguments"]
            service = FirefoxService(service_args = args, log_path = log_path)
            return service
        
        def RunDriver(path: str | None = None, json_string: str | None = None) -> None:
            # loads json file or loads the string and instanciates the actions par and the 
            loaded_dict: dict
            if type(json_string) == type(path):
                raise Exception("You either give a path to the json file or parse the json string raw, bitch.\nNOT both! Which one am I supposed to use, you expired coupon?!")
            elif path is None:
                loaded_dict = loads(json_string)
            else:
                try:
                    with open(path, 'r', encoding='utf-8') as f:
                       loaded_dict = loads(f.read())
                except FileNotFoundError:
                    raise Exception("Invalid path, file not found")
                
            driver: FirefoxDriver
            driver_options_ =  loaded_dict["driver_options"]
            global_options = loaded_dict["options"]
            print(loaded_dict)
            units: dict = loaded_dict["units"]
                

            LogJSArgs = global_options["log_JS"]
            exception_log_path = global_options["exception_log_path"]

            # create the chrome driver with arguments
            if driver_options_ != Core.Firefox.default_driver_options_dict_:
                options_: dict = driver_options_["options"]
                service_: dict = driver_options_["service"]
                
                log_path: str = service_["log_path"]
                service_args: list[str] = service_["arguments"]
                # service = FirefoxService(service_args = service_args, log_path = log_path)
                service = FirefoxService(service_args = service_args, log_path = log_path)
                opts = FirefoxOptions()
                """
                3 types of page load startegies are available:
                * normal
                * eager
                * none

                Throws a ValueError if an unsupported page load startegy type is given.
                """
                opts.page_load_strategy = options_["page_load_strategy"]

                """
                Accept insecure cert(ification)s is either true or false. Not case sensitive
                """
                opts.accept_insecure_certs = options_["accept_insecure_certs"]  # should be a bool

                """
                3 types of timeouts are available:
                * impilicit
                * pageLoad
                * script

                Throws a ValueError if an unsupported timeout type is given.

                The value of the timeout is the timespan [of the timteout] in MILLISECONDS (ms)
                """
                opts.timeouts = {options_["timeout"]["type"]: options_["timeout"]["value"]}

                """
                5 types of behaviors are available:
                * dismiss
                * accept
                * dismiss and notify
                * accept and notify
                * ignore

                Throws a ValueError if an unsupported behavior type is given.
                """
                opts.unhandled_prompt_behavior = options_["unhandled_prompt_behavior"]
        
    #        Keep the browser open-es hülyeség. Valahogy hozzá kell vágni az option-okhoz, de nem vágom hogyan...

    #       Kód:
    #            if options_["keep_browser_open"] != "":
    #                opts.add_experemental_option("detach", options_["keep_browser_open"])
    #        Eredeti error:
    #            Exception has occurred: AttributeError
    #            'Options' object has no attribute 'add_experimental_option'
    #                File "C:\Users\kmarton\OneDrive - VISION-SOFTWARE Számítástechnikai Szolgáltató és Kereskedelmi\Asztal\Projects\SeTestsVS\core_fire.py", line 168, in RunDriver
    #                    opts.add_experimental_option("detach", options_["keep_browser_open"])
    #                    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    #                File "C:\Users\kmarton\OneDrive - VISION-SOFTWARE Számítástechnikai Szolgáltató és Kereskedelmi\Asztal\Projects\SeTestsVS\main_fire.py", line 4, in <module>
    #                    Run(json)
    #            AttributeError: 'Options' object has no attribute 'add_experimental_option'


                for option in options_["browser_arguments"]:
                    opts.add_argument(option)

            # create the chrome driver (as bare bones as it gets)
            elif driver_options_ == Core.Firefox.default_driver_options_dict_:
                opts = Core.Firefox.DefaultOptions()
                service = Core.Firefox.DefaultService()
            else:
                raise Exception("Some shit got fucked up")
            
            with open(exception_log_path, mode='w', encoding='utf8') as f:
                f.write("")

            active_binds = []
            driver = FirefoxDriver(options = opts)   # , service = service
            for  uname, unit in units.items():
                try:
                    if uname in active_binds:
                        with open(exception_log_path, mode='a', encoding='UTF-8') as f:
                                f.write(f"\n{uname} skipped because previous unit failed\n")
                        continue
    
                    actions = unit['actions']
                    for index, action in actions.items():
                        print(action)
                        if action["break"]:
                           pass        # majd ide kell egy intermediate comms file megint mint a JS-nél
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
                                Core.Firefox.execute_js(driver, commands, log_JS_args=LogJSArgs)
                            case "wait":
                                time = action["amount"]
                                Core.Firefox.wait(driver = driver, time_ = time)
                            case "wait_for":
                                Core.Firefox.waitFor(driver, action)
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
                    """
                except Exception as e:
                    bindings = unit['bindings']
                    with open("log.txt", "a", encoding="UTF-8") as f:
                        to_write = (f"{str(e.__cause__)} — {str(e.__context__)} \n {traceback.format_exc()}")
                        f.write(to_write)
                    if bindings is None:
                        pass
                    elif type(bindings) == str:
                        active_binds.append(bindings)
                    elif type(bindings) == list:
                        for binding in bindings:
                            active_binds.append(binding)
                    else:
                        raise ValueError(f"\'bindings\' must be either string or list[string], not {type(bindings)}")
                    """
                except:
                    bindings = unit['bindings']
                    if bindings is not None:
                        if isinstance(bindings, list):
                            for binding in bindings:
                                if isinstance(binding, str):
                                    Core.Firefox.RunDriver.active_bindings.append(binding)
                                else:
                                    raise ValueError(f"Parameters in \'bindings\' must be of type str (string) not {type(binding)}")
                        elif isinstance(bindings, str):
                            Core.Firefox.RunDriver.active_bindings.append(bindings)
                        else:
                            raise ValueError(f"Parameter \'bindings\' must be of type str (string) not {type(bindings)}")

                    with open(exception_log_path, mode='a', encoding='utf-8') as f:
                        f.write("\n----------------------------------------------------------------\n")
                        f.write(f"{format_exc()}\nStack:")
                        stack = format_stack()
                        # -1 to exclude this expression from stack
                        for x in range(len(stack)-1):
                            stack_parts = stack[x].split('\n')
                            origin = stack_parts[0]
                            root = stack_parts[1]
                            f.write(f"\t[{x}] ORIGIN:\t{origin}\n\t[{x}] ROOT:{root}\n")
                        f.write("\n----------------------------------------------------------------\n")
                    
            

            #
            if driver_options_["options"]["keep_browser_open"]:
                pass
            else:
                driver.Quit()
        
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

        def goto(driver: FirefoxDriver, url: str):
            Core.Firefox.checkDriverExists(driver)
            driver.get(url)

        def back(driver: FirefoxDriver):
            Core.Firefox.checkDriverExists(driver)
            driver.back()

        def forward(driver: FirefoxDriver):
            Core.Firefox.checkDriverExists(driver)
            driver.forward()

        def refresh(driver: FirefoxDriver):
            Core.Firefox.checkDriverExists(driver)
            driver.refresh()

        def wait(driver: FirefoxDriver, time_: int):
            Core.Firefox.checkDriverExists(driver)
            time = float(time_ / 1000)
            driver.implicitly_wait(time)

        def waitFor(driver: FirefoxDriver, kwargs: dict[str]):
            timeout = kwargs['timeout']
            frequency = kwargs['frequency']
            if timeout is None:
                timeout = 1000
            if frequency is None:
                wait = WebDriverWait(driver, timeout=timeout)
            else:
                wait = WebDriverWait(driver, timeout=timeout, poll_frequency=frequency)

            condition = kwargs['condition']
            if condition in Core.Firefox.needs_element:
                locator: tuple[str, str] = ('xpath', kwargs['xpath'])
                match condition:
                    case 'presence_of_element_located':
                        wait.until(expected_conditions.presence_of_element_located(locator))
                pass
            elif condition in Core.Firefox.doesnt_need_element:
                match condition:
                    case 'alert':
                        wait.until(expected_conditions.alert_is_present())
                    case 'title_is':
                        wait.until(expected_conditions.title_is(kwargs['title']))
                    case 'title_contains':
                        wait.until(expected_conditions.title_contains(kwargs['title']))
            else:
                raise ValueError(f"\'{condition}\' is not a valid condition to await")
        

        # PART FUNCS
        def matchElement(_obj: WebElement | FirefoxDriver, **action_kwargs) -> WebElement:

            locator = action_kwargs["locator"]
            value = action_kwargs["value"]

            if locator is None:
                # practically impossible, but just in case
                raise ValueError("Locator must be a string, not None")
            if value is None:
                # practically impossible, but just in case
                raise ValueError("Locator must be a string, not None")

            isDisplayed = action_kwargs["isDisplayed"]
            if isDisplayed is not None:
                # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
                assert isDisplayed == _obj.is_displayed(), f"Element is{' 'if isDisplayed is False else 'not '}displayed"
            isSelected = action_kwargs["isSelected"]
            if isSelected is not None:
                # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
                assert isSelected == _obj.is_selected(), f"Element is{' 'if isDisplayed is False else ' not '}selected"
            isEnabled = action_kwargs["isEnabled"]
            if isEnabled is not None:
                # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
                assert isEnabled == _obj.is_enabled(), f"Element is{' 'if isDisplayed is False else ' not '}enabled"

            match locator:
                case "css_selector":
                    return _obj.find_element(By.CSS_SELECTOR, value)
                case "xpath":
                    return _obj.find_element(By.XPATH, value)
                case _:
                    raise ValueError(f"Invalid locator {locator}")

        def matchElements(_obj: FirefoxDriver, **action_kwargs) -> list[WebElement]:

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
                    elements = _obj.find_elements(By.CSS_SELECTOR, value)
                case "xpath":
                    elements = _obj.find_elements(By.XPATH, value)
                case _:
                    raise ValueError(f"Invalid locator {locator}")
            isDisplayed = action_kwargs["isDisplayed"]

            if isDisplayed is not None:
                # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
                for element in elements:
                    assert isDisplayed == _obj.is_displayed(), f"Element is{' 'if isDisplayed is False else 'not '}displayed"
            isSelected = action_kwargs["isSelected"]
            if isSelected is not None:
                # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
                for element in elements:
                    assert isSelected == _obj.is_selected(), f"Element is{' 'if isDisplayed is False else ' not '}selected"
            isEnabled = action_kwargs["isEnabled"]
            if isEnabled is not None:
                # Checks for for the condition, if it isn't it throws an error. Kinda weird syntax but it wokrs
                for element in elements:
                    assert isEnabled == _obj.is_enabled(), f"Element is{' 'if isDisplayed is False else ' not '}enabled"
            
            return elements

        def executeElementAction(
                _obj: WebElement,
                **action_kwargs
                ) -> bool | None:
            
            # match action
            pass

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

        def logJS(log_JS_args: dict[str, str | list | int | bool | None], log: str | SeJSException) -> None:
            from time import sleep
            from os.path import exists

            path: str = log_JS_args['path']
            fuckup: int | float = log_JS_args['retry_timeout']  / 1000

            try:
                assert exists(path), F"{path} does not exist"
            except AssertionError:
                if log_JS_args["create_path"]:
                    with open(path, mode='w', encoding='utf-8') as f:
                        pass
                else:
                    raise       # raises the original AssertionError

            if log_JS_args['terminal_mode']:
                with open(path, 'a', encoding='utf-8') as f:
                    if isinstance(log, SeJSException):
                        stacktrace = "\n".join(log.stacktrace)
                        to_write: str = f"{log.msg}\nSteack Trace:\n{stacktrace}"
                        f.write(to_write)
                    elif isinstance(log, str):
                        f.write(log)
                    else: raise ValueError("logJS takes either a string or a selenium.common.exceptions.JavascriptException as an argument")


            while True:
                with open(path, mode = 'r', encoding = "utf-8") as f:
                    contents: str = f.read()
                if contents != '':
                    sleep(fuckup)
                    continue
                else:
                    if isinstance(log, SeJSException):
                        stacktrace = "\n".join(log.stacktrace)
                        to_write: str = f"{log.msg}\nSteack Trace:\n{stacktrace}"
                        with open(path, mode ='w', encoding='utf-8') as f:
                            f.write(to_write)
                        break
                    elif isinstance(log, str):
                        with open(path, mode ='w', encoding='utf-8') as f:
                            f.write(log)
                        break
                    else: raise ValueError("logJS takes either a string or a selenium.common.exceptions.JavascriptException as an argument")

        def execute_js(
                    driver: FirefoxDriver,
                    commands: list[str],
                    log_JS_args: dict[str, str | list | int | bool | None] = \
                        {
                            "active": True,
                            "path": "./JS.log",
                            "terminal_mode": True,
                            "refresh_rate": 1000,
                            "retry_timeout": 1000
                        }
                        ):
                        Core.Firefox.checkDriverExists(driver)
                        for command in commands:
                            try:
                                driver.execute_script(command)
                            except SeJSException as e:
                                # print(f"Error: the command {command} was incorrect")
                                Core.Firefox.logJS(log_JS_args, e) #log_JS_args should be a global
                                break