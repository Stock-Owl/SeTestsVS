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
using OpenQA.Selenium.Chrome;

namespace Core
{
    //SO default: creates a new driver and then proceeds to execute the actions described
    public static class Chrome
    {
        public static void Run(
        IWebDriver? driver = null,
        ChromeOptions? options = null,
        string? pageloadstrategy = null)
        {
            if (driver != null)
            {
                if (options != null)
                {
                    throw new ArgumentNullException("options argument must be null if a driver is passed");
                }
            }
            else
            {
                if (pageloadstrategy != null)
                {
                    switch (pageloadstrategy)
                    {
                        case "normal":
                            options.PageLoadStrategy = PageLoadStrategy.Normal;
                            break;
                        case "eager":
                            options.PageLoadStrategy = PageLoadStrategy.Eager;
                            break;
                        case "none":
                            options.PageLoadStrategy = PageLoadStrategy.None;
                            break;
                        default:
                            throw new Exception("Unknown page load strategy")
                    }
                }
                driver = new ChromeDriver(options);
            }
            // iterate through all of the instructions
            
            driver.Quit();
        }
    }
    public static class Firefox
    {
        //static sub method stuff
        //the parent object (on which the method is performed) will be created and disposed of in a single parent function of the class
        //objects passed by reference!!!
        //all sub functions (private?) static as well

    }

}