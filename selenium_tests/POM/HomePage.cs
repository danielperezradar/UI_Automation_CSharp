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
using selenium_tests.Base;

namespace selenium_tests.POM
{
    public class HomePage : UnoPages
    {
        [FindsBy(How = How.XPath, Using = "//button[text()='Accept']")]
        private IWebElement CacheButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()=' Resources ']")]
        private IWebElement ResourcesMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()=' Blog ']")]
        private IWebElement BlogPage { get; set; }

        public HomePage() : base()
        {
        }

        public void GoToBlogPage()
        {
            browser.Click(ResourcesMenu);
            browser.Click(BlogPage);
        }

        public void ClickCacheButton()
        {
            browser.Click(CacheButton);
        }
    }
}