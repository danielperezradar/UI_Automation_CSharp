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
using SeleniumExtras.PageObjects;

namespace selenium_tests.Base
{
    public class UnoPages
    {   
        protected UnoBrowser browser = new UnoBrowser();
        protected IWebDriver driver;
        
        public UnoPages()
        {
            driver = browser.CreateBrowser();
            PageFactory.InitElements(driver, this);
        }

        public void Finish()
        {
            browser.Finish();
        }
    }
}