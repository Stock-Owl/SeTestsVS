from selenium import webdriver
from selenium.webdriver.chrome.service import Service as ChromeService
from selenium.webdriver.firefox.service import Service as FirefoxService
# from selenium.webdriver.chrome.options import Options
from json import loads
import selenium
# from selenium.webdriver.chrome.webdriver import WebDriver as chromedriver

# chrome webdriver type: selenium.webdriver.chrome.webdriver.WebDriver

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

            options_ = loaded_dict["options"]
            if options_ != []:
                # TODO: args need to be joined via " ".join(iterable) bc lists are for pussies
                log_path = options_["service_log_path"]
                service_args = options_["service_args"]
                service = ChromeService(service_args = service_args, log_path = log_path)

                opts = webdriver.ChromeOptions()
                opts.page_load_strategy = options_["page_load_strategy"]        # should be a string
                opts.accept_insecure_certs = options_["accept_insecure_certs"]  # should be a bool
                opts.timeouts = options_["timeouts"] # should be a timeout of some sort
                opts.unhandled_prompt_behavior = options_["unhandled_promt_behavior"] # should be on of the following:
                # dismiss, accept, dismiss and notify, accept and notify, ignore
                for each in options_:
                    opts.add_argument(each)
                driver = webdriver.Chrome(options = opts, service = service)
            else:
                driver = webdriver.WebDriver()
            #
            driver.Quit()
        
        def goto(driver: object, url: str):
            Core.Chrome.checkDriverExists(driver)
            driver.get(url)

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
