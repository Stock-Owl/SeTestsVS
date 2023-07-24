from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.remote.webdriver import WebDriver
from selenium import webdriver
from selenium.webdriver.common.by import By

driver = webdriver.Chrome()

def document_initialised(driver):
    return driver.execute_script("return 0")

driver.get("https://wikipedia.org")
WebDriverWait(driver, timeout=10).until(document_initialised, message = "your mom")
print("done")
  