using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace selenium_tests {
    public class BasePage
    {
        IWebDriver driver;
        string driverName;

        public string DriverName
        {
            get
            {
                return driverName;
            }

            set
            {
                driverName = value;
            }
        }

        // --- Driver --- //
        
        public IWebDriver SetupDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }
        
        public void Close_Driver()
        {
            driver.Quit();
        }

        public void GoToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public DefaultWait<IWebDriver> WaitElement(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            return fluentWait;
        }
        
        // --- Actions --- //

        public IWebElement FindOneElement(By locator)
        {
            IWebElement element = null;

            try
            {
                element = WaitElement(driver).Until(x => x.FindElement(locator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"The element { locator } has not been found in the DOM, try with other element o selector");
            }

            return element;
        }
        
        public void Click(By locator)
        {
            FindOneElement(locator).Click();
        }
        
        public void EnterText(By locator, string value)
        {
            FindOneElement(locator).SendKeys(value);
        }
        
        public void SelectOption(By locator, int value)
        {
            IWebElement element = FindOneElement(locator);
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(value.ToString());
        }

        public void AssertText(string expected, string actual)
        {
            ClassicAssert.AreEqual(expected, actual);
            if (expected == actual)
            {
                Console.WriteLine("Successful assertion");
            } 
            else
            {
                Console.WriteLine("Failed assertion");
            }
        }

        // --- Get --- //

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetText(By locator)
        {
            return FindOneElement(locator).Text;
        }

        // --- Booleans --- //

        public bool IsDisplayed(By locator)
        {
            return FindOneElement(locator).Displayed;
        }

        // --- Helpers --- //

        public string RandomNumber(int length)
        {
            Random random = new Random();
            string number = string.Empty;
        
            for (int i = 0; i < length; i++)
            {
                number = String.Concat(number, random.Next(10).ToString());
            }
            return number;
        }
    }
}