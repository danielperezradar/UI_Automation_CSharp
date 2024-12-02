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

namespace selenium_tests.POM
{
    public class BlogPage : HomePage
    {
        [FindsBy(How = How.XPath, Using = "//h1")]
        private IWebElement MainTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Testing & Quality Assurance']")]
        private IWebElement QACategoryBlog { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()=' The Crucial Difference Between Verification and Validation in Testing ']")]
        private IWebElement QAResult { get; set; }

        public BlogPage() : base()
        {
        }

        public void GoToQACategoryBlog()
        {
            browser.Click(QACategoryBlog);
        }

        public bool IsMainTitlePresent()
        {
            return browser.IsElementDisplayed(MainTitle);
        }

        public bool IsQAResultPresent()
        {
            return browser.IsElementDisplayed(QAResult);
        }
    }
}