from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from seleniumwire.webdriver import Firefox as WireFirefoxDriver     # selenium-wire because that supports the HTTP request interception 
from seleniumwire.webdriver import Chrome as WireChromeDriver       # selenium-wire because that supports the HTTP request interception

from selenium.webdriver.common.by import By
from selenium.common.exceptions import NoSuchElementException as ElementNotFound
from selenium.common.exceptions import NoAlertPresentException as AlertNotFound

import time
from multiprocessing import Process, Array

BOOL: str = 'b'

# CONDITIONS
# element loaded
# element visible / displayed
# url is / contains
# title is / contains
# alert present

# TODO: should be doing this shit with multiprocessing, so we suck dick once again!

class Wait:
    def Wait(time_: int, raw: bool = False) -> None:
        if not raw:
            time_ /= 1000
        time.sleep(time_)

    def WaitFor(
        frequency_ms: int = 1000,  # ms
        timeout_ms: int = 10000,   # ms
        logic_modifier: str = '?',
        conditions_: list[dict[str, str | int]] = []
        ) -> None:

        frequency: int | float = frequency_ms / 1000
        timeout: int | float = timeout_ms / 1000

        conditions: list[dict[str, str | int]] = conditions_

        assert conditions != list(), "default argument `conditions_` must not be empty"

        returned: list[bool] = []


        match logic_modifier:
            # true
            case "?":
                pass
            # false / not
            case "!":
                pass
            # or
            case "|":
                pass
            # xor
            case "^":
                pass
            # nor
            case "!|":
                pass
            # xnor
            case "!^":
                pass
            # undefined
            case _:
                raise ValueError(f"Argument `logic_modifier` expected to be one of the following: ?, !, |, ^, !|, !^ not {logic_modifier}")

    def Check(
            driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver = None, 
            condition: dict[str, str | int] = None) -> bool:
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

    def CheckPoller(
            driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver = None, 
            condition: dict[str, str | int] = None,
            frequency: int = None,
            timeout: int = None,
            shared_array: Array = None) -> None:
        pass

