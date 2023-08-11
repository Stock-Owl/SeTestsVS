from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.chrome.options import Options as ChromeOptions
# from selenium.webdriver.chrome.service import Service as ChromeService
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from selenium.webdriver.firefox.options import Options as FirefoxOptions
from selenium.webdriver.firefox.service import Service as FirefoxService
from selenium.webdriver.remote.webelement import WebElement
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions
from selenium.common.exceptions import JavascriptException as SeJSException

from support import Support

from traceback import format_exc, format_stack
from json import loads
import multiprocessing as mp

# V.1.0
#                                                                               20 / 21 + 1
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
# TODO: multiprocessing funny (O = O(n)/2)                                      ❌  21

# null nem lesz, mert C# for whatever reason, úgyhogy helyette ez van!
# Not used yet
# none = ""

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
        "browser_arguments": [],
        "service_arguments": []
    }
    def DefaultFirefoxOptions(service_logpath: str) -> tuple[FirefoxOptions, FirefoxService]:
        from copy import copy
        defaults = copy(Core.default_driver_options_dict_)
        options = FirefoxOptions()
        options.page_load_strategy = defaults["page_load_strategy"]
        options.accept_insecure_certs = defaults["accept_insecure_certs"]
        options.timeouts = {defaults["timeout"]["type"]: defaults["timeout"]["value"]}
        options.unhandled_prompt_behavior = defaults["unhandled_prompt_behavior"]
        options.add_experimental_option("detach", defaults["keep_browser_open"])
        for option in defaults["browser_arguments"]:
                options.add_argument(option)
        service_args: list[str] = defaults["service_arguments"]
        service = FirefoxService(service_args = service_args, log_path = service_logpath)
        return (options, service)        
    
    def RunFirefoxDriver(path: str | None = None, json_string: str | None = None) -> None:
        # loads json file or loads the string and instanciates the actions par and the 
        loaded_dict: dict
        if type(json_string) == type(path):
            log_line: str = ("You either give a path to the json file or parse the json string raw, bitch.\nNOT both! Which one am I supposed to use, you expired coupon?!")
            Support.LogError("./logs", log_line)
            return None
        elif path is None:
            loaded_dict = loads(json_string)
        else:
            try:
                with open(path, 'r', encoding='utf-8') as f:
                    loaded_dict = loads(f.read())
            except FileNotFoundError:
                log_line: str = "Invalid path, file not found"
                Support.LogError("./logs", log_line)
                return None                
        driver: FirefoxDriver
        driver_options_ =  loaded_dict["driver_options"]
        global_options = loaded_dict["options"]
        #print(loaded_dict)
        units: dict = loaded_dict["units"]                
        LogJSArgs = global_options["log_JS"]
        exception_log_path = global_options["exception_log_path"]
        parent_log_path = global_options["parent_log_path"]
        terminal_mode = global_options["terminal_mode"]
        # create the chrome driver with arguments
        if driver_options_ != Core.default_driver_options_dict_:
            # creates the firefox service since for firefox that's a reqirement
            log_path: str = f"{parent_log_path}/service.log"
            service_args: list[str] = driver_options_["service_arguments"]
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
            for option in driver_options_["browser_arguments"]:
                opts.add_argument(option)
        # create the chrome driver (as bare bones as it gets)
        elif driver_options_ == Core.default_driver_options_dict_:
            defaults: tuple[FirefoxOptions, FirefoxService] = Core.DefaultFirefoxOptions()
            opts = defaults[0]
            service = defaults[1]
        else:
            Support.LogError(parent_log_path, "Some shit got fucked up. But I have no clue what exactly.")
        driver = FirefoxDriver(options = opts, service = service)
        Support.ClearAllLogs(parent_log_path) # Átmegy takarítónőbe... minden eltűnik
        active_binds: list[str] = []
        for  uname, unit in units.items():
            try:
                if uname in active_binds:
                    log_line = f"\'{uname}\' skipped because previous unit failed\n"
                    Support.LogProc(parent_log_path, log_line)
                    continue    
                actions = unit['actions']
                for index, action in actions.items():
                    print(action)
                    if action["break"]:
                        if terminal_mode:
                            input("press enter to resume")
                        else:
                            pass   # majd ide kell egy intermediate comms file megint mint a JS-nél
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
                            Core.ExecuteJS(driver, commands, log_JS_args=LogJSArgs)
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
                    log_line = f"[Unit:{uname}][Action:{index}] of type \'{action['type']}\' successfully executed"
                    Support.LogProc(parent_log_path, log_line)
            except:
                bindings = unit['bindings']
                if bindings is not None:
                    if isinstance(bindings, list):
                        for binding in bindings:
                            if isinstance(binding, str):
                                active_binds.append(binding)
                            else:
                                # wrong element type in string list
                                Support.LogError(parent_log_path, f"Parameters in \'bindings\' must be of type str (string) not {type(binding)}")
                    elif isinstance(bindings, str):
                        active_binds.append(bindings)
                    else:
                        # wrong elmement type for `bindings` (should be string)
                        Support.LogError(parent_log_path, f"Parameter \'bindings\' must be of type str (string) not {type(bindings)}")                    
                #Support.LogError(parent_log_path, "----------------------------------------------------------------\n")
                #Support.LogError(parent_log_path, f"{format_exc()}\nStack:\n", time_disabled=True)
                # Belezavarnak a log-ba való hibakiírásnál.
                stack = format_stack()
                # -1 to exclude this expression from stack
                for x in range(len(stack)-1):
                    stack_parts = stack[x].split('\n')
                    origin = stack_parts[0]
                    root = stack_parts[1]
                    Support.LogError(parent_log_path, f"\t[{x}] ORIGIN:\t{origin}\n\t[{x}] ROOT: {root}\t\n", time_disabled=True)
                #Support.LogError(parent_log_path, "----------------------------------------------------------------\n", time_disabled=True)
                # Úgyszintén belezavar
        if driver_options_["keep_browser_open"]:
            pass
        else:
            driver.Quit()
    
    def DefaultChromeOptions() -> ChromeOptions:
        from copy import copy
        defaults = copy(Core.default_driver_options_dict_)
        options = ChromeOptions()
        options.page_load_strategy = defaults["page_load_strategy"]
        options.accept_insecure_certs = defaults["accept_insecure_certs"]
        options.timeouts = {defaults["timeout"]["type"]: defaults["timeout"]["value"]}
        options.unhandled_prompt_behavior = defaults["unhandled_prompt_behavior"]
        options.add_experimental_option("detach", defaults["keep_browser_open"])
        for option in defaults["browser_arguments"]:
                options.add_argument(option)
        return options        
    
    def RunChromeDriver(path: str | None = None, json_string: str | None = None) -> None:
        from time import sleep
        # loads json file or loads the string and instanciates the actions par and the 
        loaded_dict: dict
        if type(json_string) == type(path):
            log_line: str = "You either give a path to the json file or parse the json string raw, bitch.\nNOT both! Which one am I supposed to use, you expired coupon?!"
            Support.LogError("./logs", log_line)
            return None
        elif path is None:
            loaded_dict = loads(json_string)
        else:
            try:
                with open(path, 'r', encoding='utf-8') as f:
                    loaded_dict = loads(f.read())
            except FileNotFoundError:
                log_line: str = "Invalid path, file not found"
                Support.LogError("./logs", log_line)
                return None                
        driver: ChromeDriver
        driver_options_ =  loaded_dict["driver_options"]
        global_options = loaded_dict["options"]
        # print(loaded_dict)
        units: dict = loaded_dict["units"]
        LogJSArgs = global_options["log_JS"]
        parent_log_path: str = global_options["parent_log_path"]
        terminal_mode: bool = global_options["terminal_mode"]
        # create the chrome driver with arguments
        if driver_options_ != Core.default_driver_options_dict_:
            # service_: dict = driver_options_["service"]                
            # log_path: str = service_["log_path"]
            # service_args: list[str] = service_["arguments"]
            # Not used because the chromedriver is a bitch and crashes for some reason before even creating the driver...
            # Akkor, a kurva anyját (:
            # service = ChromeService(service_args = service_args, log_path = log_path)
            opts = ChromeOptions()
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
            if driver_options_["keep_browser_open"] != "":
                opts.add_experimental_option("detach", driver_options_["keep_browser_open"])
            for option in driver_options_["browser_arguments"]:
                opts.add_argument(option)
        # create the chrome driver (as bare bones as it gets)
        elif driver_options_ == Core.default_driver_options_dict_:
            opts = Core.DefaultChromeOptions()
            # NOT used. see line 110
            # service = Core.DefaultService()
        else:
            Support.LogError(parent_log_path, "Some shit got fucked up. But I have no clue what exactly.")
        # service commented out bc chromdriver shits itslef, ig
        driver = ChromeDriver(options = opts)   # , service = service
        # 
        # clears the previous log filed
        Support.ClearAllLogs(parent_log_path)
        active_bindings: list[str] = []
        failed_units: list[str] = []
        for uname, unit in units.items():
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
                    print(action)
                    if action["break"]:
                        if terminal_mode:
                            input("press enter to resume")
                        else:
                            pass   # majd ide kell egy intermediate comms file megint mint a JS-nél
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
                            Core.ExecuteJS(driver, commands, path=parent_log_path, log_JS_args=LogJSArgs)
                        case "wait":
                            time = action['amount']
                            Core.Wait(driver, time)
                        case "wait_for":
                            Core.WaitFor(driver, action)
                            # timeout = action['timeout']
                            # frequency = action['frequency']
                            # condition = action['condition']
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
                # so, the unit has failed, and it needs to be added to the failed units to check for backups
                failed_units.append(uname)
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

                Support.LogError(parent_log_path, "----------------------------------------------------------------\n")
                Support.LogError(parent_log_path, f"{format_exc()}\nStack:\n", time_disabled=True)
                stack = format_stack()

                # -1 to exclude this expression from stack
                for x in range(len(stack)-1):
                    stack_parts = stack[x].split('\n')
                    origin = stack_parts[0]
                    root = stack_parts[1]
                    Support.LogError(parent_log_path, f"\t[{x}] ORIGIN:\t{origin}\n\t[{x}] ROOT:{root}\n\n", time_disabled=True)
                Support.LogError(parent_log_path, "----------------------------------------------------------------\n", time_disabled=True)
        
        #
        if driver_options_["keep_browser_open"]:
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
            assert isinstance(driver, ChromeDriver)
        except AssertionError:
            if omit_exceptions:
                print("Invalid fuckin' type mate")
                return False
            raise AssertionError("Invalid fuckin' type mate")
        if omit_exceptions:            
            return True
        return None
                    