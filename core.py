from selenium import webdriver
from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.chrome.service import Service as ChromeService
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from selenium.webdriver.firefox.service import Service as FirefoxService
from selenium.webdriver.remote.webelement import WebElement
# from selenium.webdriver.chrome.options import Options
from json import loads
import selenium
from selenium.webdriver.common.by import By
from selenium.common.exceptions import JavascriptException as SeJSException
from datetime import time
import multiprocessing as mp
# from selenium.webdriver.chrome.webdriver import WebDriver as chromedriver

# chrome webdriver type: selenium.webdriver.chrome.webdriver.WebDriver
# webdriver HTML element type: selenium.webdriver.remote.webelement.WebElement

#                                                                               7 / 11
# TODO: Kitalálni, hogy vannak az argumentumok                                  ✅  1
# TODO: Megszerelni a random useless conversionöket a JSON-ből                  ✅  2
# TODO: Relative locators                                                       ❌  3
# TODO: JSON so get elements gets passed                                        ✅  4
# TODO: JS.Log setup    I.P.                                                    ✅  5
# TODO: Check the JS.log file if it's empty, only write if and only if empty    ✅  6
# TODO: JS execution on browser console action                                  ❗   7
# TODO: fix JS_log so it can use the existing driver                            ❌  8
# TODO: Get two independent processes with MP.
# Detect if one has terminated (it changes a shared variable to true/false
# on termination) And then stop the execution of the other one.
# Essentially, pipe without pipe bc pipe bulk ||                                ✅  9
# TODO: make a saparate function for logging JS
# to the JS console in the GUI (on request)                                     ✅  10
# TODO: rearrange JSON, so "options" only conatins browser options
# or  make a new object for that since there are operation-level
# varibales that must eb accessed and passed                                    ❌  11
class Core:
    class Chrome:
        def RunDriver(path: str | None = None, json_string: str | None = None) -> None:
            loaded_dict: dict
            if isinstance(path, json_string):
                raise Exception("You either give a path to the json file or parse the json string raw, bitch.\nNOT both! Which one am I supposed to use, you expired coupon?!")
            elif isinstance(path, None):
                loaded_dict = loads(json_string)
            else:
                try:
                    with open(path, 'r', encoding='utf-8') as f:
                       loaded_dict = loads(f.read())
                except FileNotFoundError:
                    raise Exception("Invalid path, file not found")
            driver: ChromeDriver
            options_ = loaded_dict["options"]
            # create the chrome driver with arguments
            if options_ != []:
                # TODO: args need to be joined via " ".join(iterable) bc lists are for pussies
                log_path: str = options_["service_log_path"]
                service_args: list[str] = options_["service_args"]
                service = ChromeService(service_args = service_args, log_path = log_path)

                opts = webdriver.ChromeOptions()

                """
                3 types of page load startegies are available:
                * normal
                * eager
                * none

                Throws a ValueError if an unsupported page load startegy type is given.
                """
                opts.page_load_strategy(options_["page_load_strategy"])

                """
                Accept insecure cert(ification)s is either true or false. Not case sensitive
                """
                opts.accept_insecure_certs(options_["accept_insecure_certs"])  # should be a bool

                """
                3 types of timeouts are available:
                * impilicit
                * pageLoad
                * script

                Throws a ValueError if an unsupported timeout type is given.

                The value of the timeout is the timespan [of the timteout] in MILLISECONDS (ms)
                """
                opts.timeouts({options_["timeout"]["type"]: options_["timeout"]["value"]})

                """
                5 types of behaviors are available:
                * dismiss
                * accept
                * dismiss and notify
                * accept and notify
                * ignore

                Throws a ValueError if an unsupported behavior type is given.
                """
                opts.unhandled_prompt_behavior(options_["unhandled_promt_behavior"])

                if options_["keep_browser_open"] != "":
                    opts.add_experimental_option("detach", options_["keep_browser_open"])

                for option in options_["browser_arguments"]:
                    opts.add_argument(option)
                driver = webdriver.Chrome(options = opts, service = service)
            # create the chrome driver (as bare bones as it gets)
            else:
                driver = webdriver.WebDriver()
            #
            if bool(options_["keep_browser_open"]):
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
                assert isinstance(driver, ChromeDriver)
            except AssertionError:
                if omit_exceptions:
                    print("Invalid fuckin' type mate")
                    return False
                raise AssertionError("Invalid fuckin' type mate")
            if omit_exceptions:            
                return True
            return None

        def goto(driver: ChromeDriver, url: str):
            Core.Chrome.checkDriverExists(driver)
            driver.get(url)

        def getElement(_obj: ChromeDriver | WebElement, _by: By | str, value: str):
            if isinstance(_by, By):
                _obj.find_element(_by, value)
            elif isinstance(_by, str):
                match _by.lower():
                    case "id":
                        _obj.find_element(By.ID, value)
                    case "name":
                        _obj.find_element(By.NAME, value)
                    case "css_selector":
                        _obj.find_element(By.CSS_SELECTOR, value)
                    case "class", "class_name":
                        _obj.find_element(By.CLASS_NAME, value)
                    case "tag", "tag_name":
                        _obj.find_element(By.TAG_NAME, value)
                    case "link", "link_text":
                        _obj.find_element(By.LINK_TEXT, value)
                    case "partial_link", "partial_link_text":
                        _obj.find_element(By.PARTIAL_LINK_TEXT, value)
                    case "xpath":
                        _obj.find_element(By.XPATH, value)
                    case _:
                        raise ValueError("This doesn't exist mate")
                    
        def execute_js(driver: ChromeDriver, commands: list[str]):
            Core.Chrome.checkDriverExists(driver)
            for command in commands:
                try:
                    driver.execute_script(command)
                except SeJSException:
                    print(f"Error: the command {command} was incorrect")
                    Core.logJS(log_JS_args, SeJSException)                  #log_JS_args should be a global

    def logJS(log_JS_args: dict[str, str | list | int | bool | None], log: str | SeJSException) -> None:
        from time import sleep
        from os.path import exists

        path: str = log_JS_args['path']
        fuckup: int | float = log_JS_args['retry_timeout']  / 1000
        assert exists(path), F"{path} does not exist"

        while True:
            with open(path, mode = 'r', encoding = "utf-8") as f:
                contents: str = f.read()
            if contents != '':
                sleep(fuckup)
                continue
            else:
                if isinstance(log, SeJSException):
                    to_write: str = f"JavaScript Error:\n{log.msg}"
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
                    
    def mpprocess(func: object):
        def proc( *args, **kwargs):
            all_args = tuple(*args, **kwargs)
            return mp.Process(target=func, args = (all_args))
        return proc()

    @mpprocess 
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
                    