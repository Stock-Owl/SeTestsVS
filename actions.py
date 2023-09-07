from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from seleniumwire.webdriver import Firefox as WireFirefoxDriver     # selenium-wire because that supports the HTTP request interception 
from seleniumwire.webdriver import Chrome as WireChromeDriver       # selenium-wire because that supports the HTTP request interception
from selenium.webdriver.remote.webelement import WebElement
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions
from selenium.common.exceptions import JavascriptException as SeJSException
from support import Support
from interceptor import Interceptor
from wait import Wait as Waitclass

# renaming shit from the wait class, because code segmentation

class Actions:
    def Goto(driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver, url: str):
        Actions.CheckDriverExists(driver)
        driver.get(url)

    def Back(driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver):
        Actions.CheckDriverExists(driver)
        driver.back()

    def Forward(driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver):
        Actions.CheckDriverExists(driver)
        driver.forward()

    def Refresh(driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver):
        Actions.CheckDriverExists(driver)
        driver.refresh()

    def InterceptorOn(driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver, interceptor: Interceptor):
        Actions.CheckDriverExists(driver)
        Actions.CheckInterceptorExists(interceptor)
        driver.request_interceptor = interceptor

    def InterceptorOff(driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver):
        Actions.CheckDriverExists(driver)
        driver.request_interceptor = None

    def InterceptorAdd(interceptor: Interceptor, name_: str, type_: str, key_: str, value_: str):
        Actions.CheckInterceptorExists(interceptor)
        interceptor.Add(name_, type_, key_, value_)

    def InterceptorRemove(interceptor: Interceptor, name_: str):
        Actions.CheckInterceptorExists(interceptor)
        interceptor.Remove(name_)

    WaitFor = Waitclass.WaitFor
    Wait = Waitclass.Wait

    def SwitchBack(driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver):
        Actions.CheckDriverExists(driver)
        driver.switch_to.parent_frame()

    def ExecuteJS(
        driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver,
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
            driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver,
            **action_kwargs) -> WebElement:
                   
        Actions.CheckDriverExists(driver)

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
            assert isDisplayed == element.is_displayed(), f"Element is{' 'if isDisplayed is False else ' not '}displayed"

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
            driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver,
            **action_kwargs) -> list[WebElement]:
        
        Actions.CheckDriverExists(driver)

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
                    assert isDisplayed == element.is_displayed(), f"Element is{' 'if isDisplayed is False else ' not '}displayed"

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
            driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver,
            **action_kwargs) -> None:
        
        Actions.CheckDriverExists(driver)

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

        # only switch back from iframe if the action wasn't a switch to an iframe (no counterproductivity hehe)
        if action_kwargs["auto_exit_iframes"] and action != "switch_to":                                  
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
            assert isinstance(driver, ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver)
        except AssertionError:
            if omit_exceptions:
                print(f"Invalid fuckin' type mate ({driver}:{type(driver)})")
                return False
            raise AssertionError(f"Invalid fuckin' type mate ({driver}:{type(driver)})")
        if omit_exceptions:            
            return True
        return None

    def CheckInterceptorExists(interceptor: Interceptor, omit_exceptions: bool = True) -> None | bool | Exception:
        try:
            assert interceptor
        except AssertionError:
            if omit_exceptions:
                print("Shit doesn't exist mate")
                return False
            raise AssertionError("Shit doesn't exist mate")
            
        try:
            assert isinstance(interceptor, Interceptor)
        except AssertionError:
            if omit_exceptions:
                print(f"Invalid fuckin' type mate ({interceptor}:{type(interceptor)})")
                return False
            raise AssertionError(f"Invalid fuckin' type mate ({interceptor}:{type(interceptor)})")
        if omit_exceptions:            
            return True
        return None