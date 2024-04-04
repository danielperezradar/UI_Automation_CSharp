using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace selenium_tests;

public class SeleniumTest
{
    IWebDriver driver;

    [SetUp]
    public void start_Browser()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    [Category("Google")]
    public void firstTest()
    {
        driver.Navigate().GoToUrl("https://www.amazon.com.mx/");
    }

    [TearDown]
    public void close_Browser()
    {
        driver.Quit();
    }
}