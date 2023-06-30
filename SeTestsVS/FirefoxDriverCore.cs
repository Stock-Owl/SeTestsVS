using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeTestCore
{
    public static class FirefoxActionsCore
    {
        //static sub method stuff
        //the parent object (on which the method is performed) will be created and disposed of in a single parent function of the class
        //objects passed by reference!!!
        //all sub functions (private?) static as well

        #region RunDriver Overloads

        public static void RunDriver()
        {
            FirefoxDriver driver = new FirefoxDriver();
            driver.Quit();
        }

        public static void RunDriver(FirefoxDriver driver)
        {
            driver.Quit();
        }

        public static void RunDriver(FirefoxOptions options)
        {
            FirefoxDriver driver = new FirefoxDriver(options);
            driver.Quit();
        }

        public static void RunDriver(FirefoxProfile profile)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            //
            FirefoxDriver driver = new FirefoxDriver(options);
            driver.Quit();
        }

        public static void RunDriver(FirefoxOptions options, FirefoxProfile profile)
        {
            options.Profile = profile;
            //
            FirefoxDriver driver = new FirefoxDriver(options);
            driver.Quit();
        }

        public static void RunDriver(FirefoxOptions options, string argument)
        {
            options.AddArgument(argument);
            //
            FirefoxDriver driver = new FirefoxDriver(options);
            driver.Quit();
        }

        public static void RunDriver(FirefoxOptions options, string[] arguments)
        {
            options.AddArguments(arguments);
            //
            FirefoxDriver driver = new FirefoxDriver();
            driver.Quit();
        }

        public static void RunDriver(FirefoxOptions options, IEnumerable<string> arguments)
        {
            options.AddArguments(arguments);
            //
            FirefoxDriver driver = new FirefoxDriver();
            driver.Quit();
        }

        public static void RunDriver(FirefoxOptions options, FirefoxProfile profile, string argument)
        {
            options.Profile = profile;
            options.AddArgument(argument);
            //
            FirefoxDriver driver = new FirefoxDriver();
            driver.Quit();
        }

        public static void RunDriver(FirefoxOptions options, FirefoxProfile profile, string[] arguments)
        {
            options.Profile = profile;
            options.AddArguments(arguments);
            //
            FirefoxDriver driver = new FirefoxDriver();
            driver.Quit();
        }

        public static void RunDriver(FirefoxOptions options, FirefoxProfile profile, IEnumerable<string> arguments)
        {
            options.Profile = profile;
            options.AddArguments(arguments);
            //
            FirefoxDriver driver = new FirefoxDriver();
            driver.Quit();
        }

        #endregion

        #region NewDriver Overloads

        public static void NewDriver(FirefoxOptions options)
        {
            FirefoxDriver driver = new FirefoxDriver(options);
        }
        
        public static void NewDriver(FirefoxProfile profile)
        {
            FirefoxOptions options = NewOptions(profile);
            FirefoxDriver driver = new FirefoxDriver(options);
        }

        public static void NewDriver(FirefoxOptions options, FirefoxProfile profile)
        {
            options.Profile = profile;
            FirefoxDriver driver = new FirefoxDriver(options);
        }

        #endregion

        #region NewOptions Overloads
        public static FirefoxOptions NewOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            return options;
        }

        public static FirefoxOptions NewOptions(FirefoxProfile profile)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            return options;
        }

        public static FirefoxOptions NewOptions(FirefoxProfile profile, string argument)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            options.AddArgument(argument);
            return options;
        }

        public static FirefoxOptions NewOptions(FirefoxProfile profile, string[] arguments)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            options.AddArguments(arguments);
            return options;
        }

        public static FirefoxOptions NewOptions(FirefoxProfile profile, IEnumerable<string> arguments)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            options.AddArguments(arguments);
            return options;
        }
        #endregion 

        private static void GoToUrl(FirefoxDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

    }

    /**public class FirefoxCore
    {
        private FirefoxDriver driver;
        private string _logLocation;
        private string _tempPath;

        public void Cleanup()
        {
            if (_logLocation != null && File.Exists(_logLocation))
            {
                File.Delete(_logLocation);
            }
            if (_tempPath != null && File.Exists(_tempPath))
            {
                File.Delete(_tempPath);
            }
            driver.Quit();
        }

        public void BasicOptions()
        {
            var options = new FirefoxOptions();
            driver = new FirefoxDriver(options);
        }

        public void Arguments()
        {
            var options = new FirefoxOptions();
            options.AddArgument("-headless");
            driver = new FirefoxDriver(options);
        }

        public void LogsToFile()
        {
            var service = FirefoxDriverService.CreateDefaultService();
            //service.LogFile = _logLocation

            driver = new FirefoxDriver(service);
            var lines = File.ReadLines(GetLogLocation());
            Assert.IsNotNull(lines.FirstOrDefault(line => line.Contains("geckodriver	INFO	Listening on")));
        }

        public void LogsToConsole()
        {
            var stringWriter = new StringWriter();
            var originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            var service = FirefoxDriverService.CreateDefaultService();
            //service.LogToConsole = true;

            driver = new FirefoxDriver(service);
            Assert.IsTrue(stringWriter.ToString().Contains("geckodriver	INFO	Listening on"));
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }

        public void LogsLevel()
        {
            var service = FirefoxDriverService.CreateDefaultService();
            //service.LogFile = _logLocation

            service.LogLevel = FirefoxDriverLogLevel.Debug;

            driver = new FirefoxDriver(service);
            var lines = File.ReadLines(GetLogLocation());
            Assert.IsNotNull(lines.FirstOrDefault(line => line.Contains("Marionette\tDEBUG")));
        }

        public void StopsTruncatingLogs()
        {
            var service = FirefoxDriverService.CreateDefaultService();
            //service.TruncateLogs = false;

            service.LogLevel = FirefoxDriverLogLevel.Debug;

            driver = new FirefoxDriver(service);
            var lines = File.ReadLines(GetLogLocation());
            Assert.IsNull(lines.FirstOrDefault(line => line.Contains(" ... ")));
        }

        public void SetProfileLocation()
        {
            var service = FirefoxDriverService.CreateDefaultService();
            // service.ProfileRoot = GetTempDirectory();

            driver = new FirefoxDriver(service);

            string profile = (string)driver.Capabilities.GetCapability("moz:profile");
            string[] directories = profile.Split("/");
            var dirName = directories.Last();
            Assert.AreEqual(GetTempDirectory() + "/" + dirName, profile);
        }

        public void InstallAddon()
        {
            driver = new FirefoxDriver();

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string extensionFilePath = Path.Combine(baseDir, "../../../Extensions/webextensions-selenium-example.xpi");
            driver.InstallAddOnFromFile(Path.GetFullPath(extensionFilePath));

            driver.Url = "https://www.selenium.dev/selenium/web/blank.html";

            IWebElement injected = driver.FindElement(By.Id("webextensions-selenium-example"));
            Assert.AreEqual("Content injected by webextensions-selenium-example", injected.Text);
        }

        public void UnInstallAddon()
        {
            driver = new FirefoxDriver();

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string extensionFilePath = Path.Combine(baseDir, "../../../Extensions/webextensions-selenium-example.xpi");
            string extensionId = driver.InstallAddOnFromFile(Path.GetFullPath(extensionFilePath));
            driver.UninstallAddOn(extensionId);

            driver.Url = "https://www.selenium.dev/selenium/web/blank.html";
            Assert.AreEqual(driver.FindElements(By.Id("webextensions-selenium-example")).Count, 0);
        }

        public void InstallUnsignedAddon()
        {
            driver = new FirefoxDriver();

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string extensionDirPath = Path.Combine(baseDir, "../../../Extensions/webextensions-selenium-example/");
            driver.InstallAddOnFromDirectory(Path.GetFullPath(extensionDirPath), true);

            driver.Url = "https://www.selenium.dev/selenium/web/blank.html";

            IWebElement injected = driver.FindElement(By.Id("webextensions-selenium-example"));
            Assert.AreEqual("Content injected by webextensions-selenium-example", injected.Text);
        }
        
        private string GetLogLocation()
        {
            if (_logLocation != null && !File.Exists(_logLocation))
            {
                _logLocation = Path.GetTempFileName();
            }

            return _logLocation;
        }

        private string GetTempDirectory()
        {
            if (_tempPath != null && !File.Exists(_tempPath))
            {
                _tempPath = Path.GetTempPath();
            }

            return _tempPath;
        }
    }*/
}
