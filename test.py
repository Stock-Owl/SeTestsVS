from selenium import webdriver
import time

# Create a new Selenium WebDriver instance (e.g., for Chrome)
driver = webdriver.Chrome()

# Enable the browser's logging capability
driver.get('http://www.visionsoft.hu/')
driver.execute_script('console.log("Example log message")')

# Retrieve the JavaScript console logs
browser_logs = driver.get_log('browser')

# Print the logs
for log in browser_logs:
    print(log)

time.sleep(10000000)

# Close the browser
# driver.quit()