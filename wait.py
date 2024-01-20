from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from seleniumwire.webdriver import Firefox as WireFirefoxDriver     # selenium-wire because that supports the HTTP request interception 
from seleniumwire.webdriver import Chrome as WireChromeDriver       # selenium-wire because that supports the HTTP request interception

from selenium.webdriver.common.by import By
from selenium.common.exceptions import NoSuchElementException as ElementNotFound
from selenium.common.exceptions import NoAlertPresentException as AlertNotFound

import time
from math import ceil
import asyncio

# NOTE: I have no fucking clue what's the purpose of this `BOOL`
BOOL: str = 'b'

# CONDITIONS
# element loaded
# element visible / displayed
# url is / contains
# title is / contains
# alert present

class Wait:
    def Wait(
            milliseconds: int
        ) -> None:

        milliseconds /= 1000

        time.sleep(milliseconds)

    async def Check(
        driver: ChromeDriver | FirefoxDriver | WireChromeDriver | WireFirefoxDriver, 
        condition: dict[str, str | int | bool] = None,
        out: list[bool] = []
        ):

        """
            Checks if the given condition is met. Returns a boolean.\n

            Conditions:\n
            * loaded:\n
            \tChecks if the given element has been loaded
            \t```
                    "type" : "loaded"                   [str]
                    "locator": "css_selector" | "xpath" [str]
                    "value": "value_to_find"            [str]
            \t```
            * visible:\n
            \tChecks if the given element is currently visible on the page
            \t```
                    "type" : "visible"                  [str]
                    "locator": "css_selector" | "xpath" [str]
                    "value": "value_to_find"            [str]
            \t```
            * title_is:\n
            \tChecks if the page's title is equal to the given value
            \t```
                    "type" : "title_is"             [str]
                    "case_sensitive": True | False  [bool]
                    "value": "value_to_find"        [str]
            \t```
            * title_contains:\n
            \tChecks if the page's title contains the given value
            \t```
                    "type" : "title_contains"       [str]
                    "case_sensitive": True | False  [bool]
                    "value": "value_to_find"        [str]
            \t```
            * url_is:\n
            \tChecks if the page's url is equal to the given value
            \t```
                    "type" : "url_is"               [str]
                    "value": "value_to_find"        [str]
            \t```
            * url_contains:\n
            \tChecks if the page's url contains the given value
            \t```
                    "type" : "url_contains"         [str]
                    "value": "value_to_find"        [str]
            \t```
            * alert_present:\n
            \tChecks if there is a JavaScript alert present
            \t```
                    "type" : "alert_present"             [str]
            \t```
        """

        # at a lot of places, `else` statements are used rather unnecesarrily
        # they are, in fact, necessarry, because we're not returning anything
        # nromally, a return would break the program there
        # but we don't use a return anywhere to spare an instruction
        # hecne, the `else`s
        
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
                    out.append(True)
                except ElementNotFound:
                    out.append(False)
            
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
                        out.append(True)
                    else:
                        out.append(False)
                except ElementNotFound:
                    out.append(False)
            
            case "title_is":
                try:
                    if condition["case_sensitive"]:
                        if condition["title"] == driver.title:
                            out.append(True)
                    elif condition["title"].lower() == driver.title.lower():
                        out.append(True)
                    else:
                        out.append(False)
                except:
                    out.append(False)
            
            case "title_contains":
                try:
                    if condition["case_sensitive"]:
                        if condition["title"] in driver.title:
                            out.append(True)
                    elif condition["title"].lower() in driver.title.lower():
                        out.append(True)
                    else:
                        out.append(False)
                except:
                    out.append(False)
            
            case "url_is":
                try:
                    if condition["url"] == driver.current_url:
                        out.append(True)
                    else:
                        out.append(False)
                except:
                    out.append(False)
            
            case "url_contains":
                try:
                    if condition["url"] in driver.current_url:
                        out.append(True)
                    else:
                        out.append(False)
                except:
                    out.append(False)
            
            case "alert_present":
                alert_present: bool
                try:
                    driver.switch_to.alert()
                    alert_present = True
                except AlertNotFound:
                    alert_present = False

                # TODO: figure out what this is supposed to be
                if alert_present == condition["alert"]:     # FTW
                    out.append(True)
                else:
                    out.append(False)
            
            case _:
                out.append(False)
                raise ValueError(f"\'{checktype}\' is not a valid condition to await")
            
    def LogicOperatorCheck(
            operator: str,
            conditions: list[bool] | set[bool] | tuple[bool]
        ) -> bool:

        """
        Applies the specified operator on the given list. Returns a boolean.

        * all:\n
        \tReturns True if all values in `conditions` are True\n
        * any:\n
        \tReturns True if any value in `conditions` is True\n
        * n:\n
        \tReturns True if n number of  `conditions` is True\n
        * minn:\n
        \tReturns True if at least n number of `conditions` is True\n
        * maxn:\n
        \tReturns True if at most n number of `conditions` is True\n
        * ! operator:\n
        \tInverts the condition. (Replace the True at the ends with False)
        """
        
        n: int

        try:
            if operator.startswith("n"):
                n = int(operator.removeprefix("n"))
                operator = "n"
            elif operator.startswith("!n"):
                n = int(operator.removeprefix("!n"))
                operator = "!n"
        except ValueError:
            raise ValueError("Only integer numbers are allowed for counting logical operators")
        
        match operator.lower():
            case "all":
                if False not in conditions:
                    return True
                return False
            
            case "!all":
                if True not in conditions:
                    return True
                return False
            
            case "any":
                if True in conditions:
                    return True
                return False
            
            case "!any":
                if False in conditions:
                    return True
                return False
            
            case "n":
                if n is None:
                    raise ValueError("Number parameter wasn't specified for counting logic operator")
                elif conditions.count(True) == n:
                    return True
                return False
            
            case "!n":
                if n is None:
                    raise ValueError("Number parameter wasn't specified for counting logic operator")
                elif conditions.count(False) == n:
                    return True
                return False
            
            case "minn":
                if n is None:
                    raise ValueError("Number parameter wasn't specified for counting logic operator")
                elif conditions.count(True) >= n:
                    return True
                return False

            case "!minn":
                if n is None:
                    raise ValueError("Number parameter wasn't specified for counting logic operator")
                elif conditions.count(False) >= n:
                    return True
                return False

            case "maxn":
                if n is None:
                    raise ValueError("Number parameter wasn't specified for counting logic operator")
                elif conditions.count(True) <= n:
                    return True
                return False

            case "!maxn":
                if n is None:
                    raise ValueError("Number parameter wasn't specified for counting logic operator")
                elif conditions.count(False) <= n:
                    return True
                return False

            case _:
                raise ValueError(f"Incorrect logic operator '{operator}' (available: 'all', 'any', 'n), 'minn', 'maxn' or their negated counterparts (! operator)")

    async def ConditionManager(
            driver: ChromeDriver | WireChromeDriver | FirefoxDriver | WireFirefoxDriver,
            logic_operator: str = "all",
            condition_list: list[dict[str, str | int]] = [],
            frequency_ms: int = 1000, # ms
            timeout_ms: int = 10000 # ms
        ) -> None:

        frequency = frequency_ms / 1000
        timeout = timeout_ms / 1000
        iterations = ceil(timeout / frequency)

        conditions: list[asyncio.Future] = []
        for each in condition_list:
            conditions.append(Wait.Check(driver, condition = each, out = conditions))

        for coro in condition_list:
            print(type(coro))

        for each in range(iterations):
            await asyncio.gather(*conditions)
            if Wait.LogicOperatorCheck(operator = logic_operator, conditions = conditions):
                return
            time.sleep(frequency)

        raise Exception("Target timeframe wasn't met by WaitFor")

    def WaitFor(
            driver: ChromeDriver | WireChromeDriver | FirefoxDriver | WireFirefoxDriver,
            logic_operator: str = "all",
            condition_list: list[dict[str, str | int | bool]] = [],
            frequency_ms = 1000, # ms
            timeout_ms = 10000 # ms
        ) -> None:

        print("WaitFor waiting")

        if condition_list == []: return

        asyncio.run(
            Wait.ConditionManager(
                driver,
                logic_operator = logic_operator,
                condition_list = condition_list,
                frequency_ms = frequency_ms,
                timeout_ms = timeout_ms
                )
            )

        print("WaitFor done")