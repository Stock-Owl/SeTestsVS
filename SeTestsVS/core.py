from selenium import webdriver
from selenium.webdriver.chrome.options import Options
import selenium
# from selenium.webdriver.chrome.webdriver import WebDriver as chromedriver

# chrome webdriver type: selenium.webdriver.chrome.webdriver.WebDriver

class Core:
    class Chrome:
        def createDriver(options: Options | None = None) -> selenium.webdriver.chrome.webdriver.WebDriver:
            if options is None:
                driver = webdriver.Chrome()
                return driver
            driver = webdriver.WebDriver(options)
            return driver
        
        def goto(driver: object, url: str):
            Core.Chrome.checkDriverExists(driver)
            driver.get(url)

        def quit(driver: object) -> bool:
            Core.Chrome.checkDriverExists(driver)
            driver.quit()

        def checkDriverExists(driver: object, omit_exceptions: bool = True) -> None | bool | Exception:
            try:
                assert driver
            except AssertionError:
                if omit_exceptions:
                    print("Shit doesn't exist type mate")
                    return False
                raise AssertionError("Shit doesn't exist type mate")
            
            try:
                assert isinstance(driver, selenium.webdriver.chrome.webdriver.WebDriver)
            except AssertionError:
                if omit_exceptions:
                    print("Invalid fuckin' type mate")
                    return False
                raise AssertionError("Invalid fuckin' type mate")
            if omit_exceptions:            
                return True
            return None
            

driver = 1
Core.Chrome.goto(driver, 'https://google.com')
