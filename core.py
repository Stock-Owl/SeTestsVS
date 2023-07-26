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
from selenium.common.exceptions import JavascriptException as SeJSException

from json import loads
from datetime import time
import multiprocessing as mp
from copy import copy

#                                                                               12 / 13
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
# TODO: Units and binding                                                       ❌  13

none = ""

class Core:
    class Chrome:

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

        def DefaultOptions() -> ChromeOptions:
            content = Core.Chrome.default_driver_options_dict_
            opts = copy(content["options"])
            del content
            options = ChromeOptions()
            options.page_load_strategy = opts["page_load_strategy"]
            options.accept_insecure_certs = opts["accept_insecure_certs"]
            options.timeouts = {opts["timeout"]["type"]: opts["timeout"]["value"]}
            options.unhandled_prompt_behavior = opts["unhandled_prompt_behavior"]
            options.add_experimental_option("detach", opts["keep_browser_open"])
            for option in opts["browser_arguments"]:
                    options.add_argument(option)
            return options
        
        def DefaultService() -> ChromeService:
            content = Core.Chrome.default_driver_options_dict_
            serv = copy(content["service"])
            del content
            log_path: str = serv["log_path"]
            args = serv["arguments"]
            service = ChromeService(service_args = args, log_path = log_path)
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
                
            driver: ChromeDriver
            driver_options_ =  loaded_dict["driver_options"]
            global_options = loaded_dict["options"]
            print(loaded_dict)
            actions: dict = loaded_dict["actions"]

            LogJSArgs = global_options["log_JS"]

            # create the chrome driver with arguments
            if driver_options_ != Core.Chrome.default_driver_options_dict_:
                options_: dict = driver_options_["options"]
                service_: dict = driver_options_["service"]
                
                log_path: str = service_["log_path"]
                service_args: list[str] = service_["arguments"]
                service = ChromeService(service_args = service_args, log_path = log_path)

                opts = ChromeOptions()

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

                if options_["keep_browser_open"] != "":
                    opts.add_experimental_option("detach", options_["keep_browser_open"])

                for option in options_["browser_arguments"]:
                    opts.add_argument(option)

            # create the chrome driver (as bare bones as it gets)
            elif driver_options_ == Core.Chrome.default_driver_options_dict_:
                opts = Core.Chrome.DefaultOptions()
                service = Core.Chrome.DefaultService()
            else:
                raise Exception("Some shit got fucked up")
            driver = ChromeDriver(options = opts)   # , service = service
            # 
            for index, action in actions.items():
                print(action)
                if action["break"]:
                    pass        # majd ide kell egy intermediate comms file megint mint a JS-nél
                match action["type"]:
                    case "goto":
                        url = action["url"]
                        Core.Chrome.goto(driver, url)
                    case "back":
                        Core.Chrome.back(driver)
                    case "forward":
                        Core.Chrome.forward(driver)
                    case "refresh":
                        Core.Chrome.refresh(driver)
                    case "js_execute":
                        commands = action["commands"]
                        Core.Chrome.execute_js(driver, commands, log_JS_args=LogJSArgs)
                    case "wait":
                        pass
                    case "wait_for":
                        pass
                    case "click":
                        pass
                    case "send_keys":
                        pass
                    case "clear":
                        pass
            #
            if driver_options_["options"]["keep_browser_open"]:
                pass
            else:
                driver.Quit()

        def goto(driver: ChromeDriver, url: str):
            Core.checkDriverExists(driver)
            driver.get(url)

        def back(driver: ChromeDriver):
            Core.checkDriverExists(driver)
            driver.back()

        def forward(driver: ChromeDriver):
            Core.checkDriverExists(driver)
            driver.forward()

        def refresh(driver: ChromeDriver):
            Core.checkDriverExists(driver)
            driver.refresh()

        def wait(driver: ChromeDriver, time_: int):
            Core.checkDriverExists(driver)
            time = float(time_ / 1000)
            driver.implicitly_wait(time)

        # PART FUNCS

        def matchElement(_obj: WebElement | ChromeDriver, root: dict) -> WebElement:
            match root["locator"]:
                case "id":
                    return _obj.find_element(By.ID, root["value"])
                case "name":
                    return _obj.find_element(By.NAME, root["value"])
                case "css_selector":
                    return _obj.find_element(By.CSS_SELECTOR, root["value"])
                case "class":
                    return _obj.find_element(By.CLASS_NAME, root["value"])
                case "class_name":
                    return _obj.find_element(By.CLASS_NAME, root["value"])
                case "link":
                    return _obj.find_element(By.LINK_TEXT, root["value"])
                case "link_text":
                    return _obj.find_element(By.LINK_TEXT, root["value"])
                case "partial_link":
                    return _obj.find_element(By.PARTIAL_LINK_TEXT, root["value"])
                case "partial_link_text":
                    return _obj.find_element(By.PARTIAL_LINK_TEXT, root["value"])
                case "tag":
                    return _obj.find_element(By.TAG_NAME, root["value"])
                case "tag_name":
                    return _obj.find_element(By.TAG_NAME, root["value"])
                case "xpath":
                    return _obj.find_element(By.XPATH, root["value"])
                case _:
                    raise ValueError(f"Invalid locator in {root}")

        def matchElements(_obj, root: dict) -> list[WebElement]:
            match root["locator"]:
                case "id":
                    elements = _obj.find_elements(By.ID, root["value"])
                case "name":
                    elements = _obj.find_elements(By.NAME, root["value"])
                case "css_selector":
                    elements = _obj.find_elements(By.CSS_SELECTOR, root["value"])
                case "class":
                    elements = _obj.find_elements(By.CLASS_NAME, root["value"])
                case "class_name":
                    elements = _obj.find_elements(By.CLASS_NAME, root["value"])
                case "link":
                    elements = _obj.find_elements(By.LINK_TEXT, root["value"])
                case "link_text":
                    elements = _obj.find_elements(By.LINK_TEXT, root["value"])
                case "partial_link":
                    elements = _obj.find_elements(By.PARTIAL_LINK_TEXT, root["value"])
                case "partial_link_text":
                    elements = _obj.find_elements(By.PARTIAL_LINK_TEXT, root["value"])
                case "tag":
                    elements = _obj.find_elements(By.TAG_NAME, root["value"])
                case "tag_name":
                    elements = _obj.find_elements(By.TAG_NAME, root["value"])
                case "xpath":
                    elements = _obj.find_elements(By.XPATH, root["value"])
                case _:
                    raise ValueError(f"Invalid locator in {root}")
            return elements

        def executeElementAction(
                _obj: WebElement | list[WebElement],
                action: str,
                *action_args,
                isDisplayed: bool | None = None,
                isSelected: bool | None = None,
                isEnabled: bool | None = None,
                **action_kwargs
                ) -> bool | None:
            if isDisplayed is not None:
                assert isDisplayed == _obj.is_displayed(), f"Element is{' 'if isDisplayed is False else 'not '}displayed"
            if isSelected is not None:
                assert isSelected == _obj.is_selected(), f"Element is{' 'if isDisplayed is False else ' not '}selected"
            if isEnabled is not None:
                assert isEnabled == _obj.is_enabled(), f"Element is{' 'if isDisplayed is False else ' not '}enabled"

            match action:
                case "wait_for":
                    args: dict = action_kwargs
                    timeout = args['timeout']
                    frequency = args['frequency']
                    if frequency is None:
                        frequency = 1000
                    wait = WebDriverWait(args['driver'], timeout=timeout)
                    
                case "click":
                    _obj.click()
                case "send_keys":
                    _obj.send_keys(**action_kwargs['keys'])
                case "clear":
                    _obj.clear()
                case _:
                    raise ValueError("Invalid action type")
                

        def getElement(
                driver: ChromeDriver,
                _obj: ChromeDriver | WebElement,
                root: dict,
                isSingle: bool = True
                ) -> WebElement | list[WebElement]:
            # * get the element specified  
            # * if the next element is None, return the found element, else call again
            # * if the type of the element is iframe, then switch the driver into the iframe, then call again
            # * if the element to be returned is not single, use the group returning method
            # print(f"root {root}\nroot object: {_obj}\n element: {root['element']}")
            result: WebElement | list[WebElement]
            if root['element'] is None:
                if isSingle:
                    result = Core.Chrome.matchElement(_obj, root)
                    print(f"returned result: {result}, tag: {result.tag_name} \n")
                    return result.tag_name
                elif isSingle == False:
                    result = Core.Chrome.matchElements(_obj, root)
                    print(f"returned result: {result}, tag: {result.tag_name} \n")
                    return result.tag_name
            else:
                result = Core.Chrome.matchElement(_obj, root)
                # print(f"\nobj: {_obj} \nresult: {result} \n")
                Core.Chrome.getElement(driver, result, root['element'], isSingle = isSingle)
            
            if root['type'] == 'iframe':
                driver.switch_to.frame(result)
                    
        def execute_js(
            driver: ChromeDriver,
            commands: list[str],
            log_JS_args: dict[str, str | list | int | bool | None] = \
                {
                    "active": True,
                    "path": "./JS.log",
                    "refresh_rate": 1000,
                    "retry_timeout": 1000
                }
            ):
            Core.checkDriverExists(driver)
            for command in commands:
                try:
                    driver.execute_script(command)
                except SeJSException as e:
                    # print(f"Error: the command {command} was incorrect")
                    Core.logJS(log_JS_args, e) #log_JS_args should be a global
                    break

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
            assert isinstance(driver, ChromeDriver)
        except AssertionError:
            if omit_exceptions:
                print("Invalid fuckin' type mate")
                return False
            raise AssertionError("Invalid fuckin' type mate")
        if omit_exceptions:            
            return True
        return None
                    
    def auto_logJS(driver: ChromeDriver, log_JS_args: dict[str, str | list | int | bool | None]) -> None:
            from time import sleep
            from os.path import exists
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

            path: str = log_JS_args['path']
            mimir: int | float = log_JS_args['refresh_rate']    / 1000
            fuckup: int | float = log_JS_args['retry_timeout']  / 1000
            assert log_JS_args['active'] == True, "terminating"
            assert exists(path), f"{path} does not exist"


            while True:
                browser_logs = driver.get_log("browser")
                try:
                    assert driver
                except AssertionError:
                    break
                with open(path, mode = 'r+', encoding = 'utf-8') as f:
                    contents = f.read()
                if contents == '':
                    with open(path, mode = 'a+', encoding = 'utf-8') as f:
                        for log in browser_logs:
                            log_line = \
                            f"{log['source']} — {log['level']}:\n{log['message']}\n\t{log['timestamp']}"
                            f.write(log_line)
                    sleep(mimir)
                else:
                    sleep(fuckup)

jsonstring = """{
    "browser": "chrome",
    "options":
    {
        "log_JS": 
        {
            "active": true,
            "path": "./JS.log",
            "refresh_rate": 1000,
            "retry_timeout": 1000
        }
    },
    "driver_options":
    {
        "options":
        {
            "page_load_strategy": "normal",
            "accept_insecure_certs": false,
            "timeout":
            {
                "type": "pageLoad",
                "value": 300000
            },
            "unhandled_prompt_behavior": "dismiss and notify",
            "keep_browser_open": true,
            "browser_arguments": []
        },
        "service":
        {
            "log_path": ".",
            "arguments": []
        }
    },
    
    "actions":
    {
    "2":
        {
            "type": "goto",
            "break": false,
            "url": "https://wikipedia.org"
        },
    "1":
        {
            "type": "js_execute",
            "break": false,
            "commands":
            [
                "console.log('Anyád')"
            ]
        }
    }
}"""

test_dict: dict = \
{
    "single": True,
    "element":
    {
        "type": "element",
        "locator": "class",
        "value": "central-textlogo",
        "element": {
            "type": "element",
            "locator": "class",
            "value": "central-featured-logo",
            "element": None
        }
    }
}

