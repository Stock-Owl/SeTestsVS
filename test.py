from selenium import webdriver
from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.chrome.options import Options as ChromeOptions
from selenium.webdriver.chrome.service import Service as ChromeService

options = ChromeOptions()
options.accept_insecure_certs = True
options.page_load_strategy = "normal"
options.unhandled_prompt_behavior = "dismiss and notify"
options.add_experimental_option("detach", True)

service = ChromeService(service_args=['--log-level=DEBUG'], log_path = "./service.log")
driver = ChromeDriver(options=options, service=service)

print("works")

driver.quit()
