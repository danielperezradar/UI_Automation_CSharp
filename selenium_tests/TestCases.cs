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
using selenium_tests.POM;

namespace selenium_tests
{
    public class TestCases
    {
        BlogPage blogPage;

        [SetUp]
        public void BeforeTest()
        {
            blogPage = new BlogPage();
        }

        [Test]
        public void Unosquare_BlogValidation()
        {   
            blogPage.ClickCacheButton();

            blogPage.GoToBlogPage();

            ClassicAssert.IsTrue(blogPage.IsMainTitlePresent());

            blogPage.GoToQACategoryBlog();

            ClassicAssert.IsTrue(blogPage.IsQAResultPresent());
        }

        [TearDown]
        public void close_Browser()
        {
            blogPage.Finish();
        }
    }
}