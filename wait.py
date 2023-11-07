from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from seleniumwire.webdriver import Firefox as WireFirefoxDriver     # selenium-wire because that supports the HTTP request interception 
from seleniumwire.webdriver import Chrome as WireChromeDriver       # selenium-wire because that supports the HTTP request interception

from selenium.webdriver.common.by import By
from selenium.common.exceptions import NoSuchElementException as ElementNotFound
from selenium.common.exceptions import NoAlertPresentException as AlertNotFound

import time
from math import ceil

# CONDITIONS
# element loaded
# element visible / displayed
# url is / contains
# title is / contains
# alert present

# TODO: should be doing this shit with multiprocessing, so we suck dick once again!

class Wait:
    def Wait(milliseconds: int) -> None:
        milliseconds /= 1000
        time.sleep(milliseconds)

    def WaitFor(
        driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver,
        frequency_ms: int = 1000,  # ms
        timeout_ms: int = 10000,   # ms
        logic_modifier: str = '?',
        condition_: dict[str, str | int] = []
        ) -> None:

        frequency: int | float = frequency_ms / 1000
        timeout: int | float = timeout_ms / 1000
        iterations: int = ceil(timeout / frequency)
        satisfied: bool

        match logic_modifier:
            # true
            case "?":
                satisfied = Wait.Check(driver, condition_)
            # false / not
            case "!":
                satisfied = not Wait.Check(driver, condition_)
            # undefined
            case _:
                raise ValueError(f"Argument `logic_modifier` expected to be one of the following: ?, ! not {logic_modifier}")
        
        for _ in range(iterations):
            if satisfied:
                return
            time.sleep(frequency)
        
        raise RuntimeError("The requested condition has not been met in the given timeframe")

    def Check(
        driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver = None, 
        condition: dict[str, str | bool] = None
        ) -> bool:
        checktype = condition["type"]
        match checktype.lower():
            case "loaded":
                try:
                    locator: str = condition["locator"]
                    if locator == "xpath": 
                        driver.find_element(By.XPATH, condition["value"])
                    elif locator == "css_selector":
                        driver.find_element(By.CSS_SELECTOR, condition["value"])
                    else:
                        raise ValueError(f"Parameter `locator` must be either 'xpath' or 'css_selector', not f{locator}")
                    return True
                except ElementNotFound:
                    return False
            case "visible":
                try:
                    locator: str = condition["locator"]
                    if locator == "xpath": 
                        visibility = driver.find_element(By.XPATH, condition["value"]).is_displayed()
                    elif locator == "css_selector":
                        visibility = driver.find_element(By.CSS_SELECTOR, condition["value"])
                    else:
                        raise ValueError(f"Parameter `locator` must be either 'xpath' or 'css_selector', not f{locator}")
                    if visibility == condition[visibility]:
                        return True
                    return False
                except ElementNotFound:
                    return False
            case "title_is":
                try:
                    if condition["case_sensitive"]:
                        if condition["title"] == driver.title:
                            return True
                    if condition["title"].lower() == driver.title.lower():
                        return True
                    return False
                except:
                    return False
            case "title_contains":
                try:
                    if condition["case_sensitive"]:
                        if condition["title"] in driver.title:
                            return True
                    if condition["title"].lower() in driver.title.lower():
                        return True
                    return False
                except:
                    return False
            case "url_is":
                try:
                    if condition["url"] == driver.current_url:
                        return True
                    return False
                except:
                    return False
            case "url_contains":
                try:
                    if condition["url"] in driver.current_url:
                        return True
                    return False
                except:
                    return False
            case "alert_present":
                alert_present: bool
                try:
                    driver.switch_to.alert()
                    alert_present = True
                except AlertNotFound:
                    alert_present = False

                if alert_present == condition["alert"]:
                    return True
                return False
            case _:
                raise ValueError(f"\'{checktype}\' is not a valid condition to await")

    class logic_modifiers:
        """
            Container class for logic modifiers
        """
        AND: str = 'and'
        OR: str = 'or'
        NAND: str = 'nand'
        NOR: str = 'nor'
        XOR: str = 'xor'
        XNOR: str = 'xnor'
        N: str = 'n'
        MINN: str = 'minn'
        MAXN: str = 'maxn'
        NOTN: str = 'notn'
        NMINN: str = 'nminn'
        NMAXN: str = 'nmaxn'

    def LogicCheck(
            logic_modifier: str,
            checklist: list[bool | None]
        ) -> bool:

        def Numextractor(string: str, logic_modifier: str) -> None | Exception:
            _ = string.removeprefix(logic_modifier)
            try:
                ret = int(_)
                return ret
            except ValueError:
                raise Exception(f"Invalid logic modifier and or unconvertable value for \'n\': {_}")

        _ = Wait.logic_modifiers

        match logic_modifier:
            # `and` returns true if all conditions evaluate to true
            case _.AND:
                if False in checklist:
                    return False
                return True
            # `or` return true if any of the conditions evaluate to true
            case _.OR:
                if True in checklist:
                    return True
                return False
            # `nand` return true if any condition evaluates to false
            case _.NAND:
                if False in checklist:
                    return True
                return False
            # `nor` return true if all conditions evaluates to false
            case _.NOR:
                if True in checklist:
                    return False
                return True
            # `xor` returns true if any condition evaluates to true but not all of them
            case _.XOR:
                if (True and False) in checklist:
                    return True
                return False
            # `xnor` returns true if either all of the conditions evaluates to true or false
            case _.XNOR:
                if True in checklist and False not in checklist:
                    return True
                elif False in checklist and True not in checklist:
                    return True
                return False
            # `n` returns true if exactly n cases evaluate to true
            case _.N:
                pass
            # `minn` returns true if at least n cases evaluate to true
            case _.MINN:
                pass
            # `maxn` returns true if at most n cases evaluate to true
            case _.MAXN:
                pass
            # `notn` returns true if exactly n cases evaluate to false
            case _.NOTN:
                pass
            # `nminn` returns true if at least n cases evaluate to false
            case _.NMINN:
                pass
            # `nmaxn` returns true if at most n cases evaluate to false
            case _.NMAXN:
                pass
            # undefined
            case _:
                pass
