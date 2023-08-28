from seleniumwire.webdriver import Chrome as ChromeDriver       # selenium-wire because that supports the HTTP request interception
from seleniumwire.webdriver import Firefox as FirefoxDriver     # selenium-wire because that supports the HTTP request interception
from selenium.webdriver.remote.webelement import WebElement
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions
from selenium.common.exceptions import JavascriptException as SeJSException
from support import Support
from interceptor import Interceptor

class Actions:
    def Goto(driver: ChromeDriver | FirefoxDriver, url: str):
        Actions.CheckDriverExists(driver)
        driver.get(url)

    def Back(driver: ChromeDriver | FirefoxDriver):
        Actions.CheckDriverExists(driver)
        driver.back()

    def Forward(driver: ChromeDriver | FirefoxDriver):
        Actions.CheckDriverExists(driver)
        driver.forward()

    def Refresh(driver: ChromeDriver | FirefoxDriver):
        Actions.CheckDriverExists(driver)
        driver.refresh()

    def InterceptorAdd(interceptor: Interceptor, name_: str, type_: str, key_: str, value_: str):
        interceptor.Add(name_, type_, key_, value_)

    def InterceptorRemove(interceptor: Interceptor, name_: str):
        interceptor.Remove(name_)

    def SwitchBack(driver: ChromeDriver | FirefoxDriver):
        driver.switch_to.parent_frame()

    def Wait(driver: ChromeDriver | FirefoxDriver, time_: int):
        Actions.CheckDriverExists(driver)
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
                element = Actions.matchElement(driver, locator = locator_, value = value_)
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
        retry_timeout: int = 1000
        ) -> None:

        Actions.CheckDriverExists(driver)
        for i in range(len(commands)):
            try:
                command = commands[i]
                driver.execute_script(command)
            except SeJSException as e:
                # print(f"Error: the command {command} was incorrect")
                Support.LogJS(path_, retry_timeout, e, index=0, terminal_mode=terminal_mode)

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
            **action_kwargs) -> None:
        
        result: WebElement | list[WebElement]
        isSingle = action_kwargs["isSingle"]
        if isSingle:
            result = Actions.MatchElement(driver, **action_kwargs)                
            action = action_kwargs["action"]
            match action:
                case "click":
                    result.click()
                case "send_keys":
                    keys = action_kwargs["keys"]
                    result.send_keys(keys)
                case "clear":
                    result.clear()
                case "switch_to":
                    driver.switch_to.frame(result)
                case _:
                    raise ValueError("Invalid action type") 
                                   
        elif isSingle == False:
            results = Actions.MatchElements(driver, **action_kwargs)
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

        if action_kwargs["auto_exit_iframes"]:                                  
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
                    