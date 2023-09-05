from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from seleniumwire.webdriver import Firefox as WireFirefoxDriver     # selenium-wire because that supports the HTTP request interception 
from seleniumwire.webdriver import Chrome as WireChromeDriver       # selenium-wire because that supports the HTTP request interception

import time
from multiprocessing import Process, Array, Value

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

    def Check(condition: str = None) -> bool:
        match condition.lower():
            case "loaded":
                pass
            case "visible":
                pass
            case "title_is":
                pass
            case "title_contains":
                pass
            case "url_is":
                pass
            case "url_contains":
                pass
            case "alert_present":
                pass
