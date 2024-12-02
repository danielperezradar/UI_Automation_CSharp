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

namespace selenium_tests.Base
{
    public class UnoBrowser
    {
        IWebDriver driver;

        public IWebDriver CreateBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            driver.Navigate().GoToUrl("https://www.unosquare.com");
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            return element.Displayed;
        }
        
        public void Finish()
        {
            driver.Quit();
        }
    }
}