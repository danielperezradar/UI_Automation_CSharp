using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace selenium_tests;

public class Exercise_BasicMaintenance
{
    IWebDriver driver;
    By GoogleSearchBar = By.XPath("//textarea[@title='Buscar']");
    By UnoSquareGoogleRecommendation = By.XPath("//li[@data-entityname='unosquare']");
    By UnoSquareGoogleResult = By.XPath("//h3[text()='Unosquare: Home Page - Smart Engineering For Your Digital ...']");
    By UnoSquareServicesMenu = By.XPath("//a[text()='Services']");
    By PracticeAreas = By.XPath("//a[text()='Industries']");
    By ContactUs = By.XPath("//span[text()='Contact Us']");
    
    [SetUp]
    public void SetUpDriver()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
    }
    
    [Test]
    [Category("Unosquare")]
    public void UnosquareTest()
    {
        driver.Navigate().GoToUrl("https://www.google.com");

        closeLoginGoogle(driver);

        SendText(driver.FindElement(GoogleSearchBar), "Unosquare");

        Click(driver.FindElement(UnoSquareGoogleRecommendation));

        Click(driver.FindElements(UnoSquareGoogleResult)[0]);

        Click(driver.FindElements(UnoSquareServicesMenu)[1]);

        ClassicAssert.AreEqual(driver.Url, "https://www.unosquare.com/services/");

        Click(driver.FindElements(PracticeAreas)[1]);

        ClassicAssert.AreEqual(driver.Url, "https://www.unosquare.com/industries/");

        Click(driver.FindElement(ContactUs));

        ClassicAssert.AreEqual(driver.Url, "https://www.unosquare.com/contact-us/");
    }

    [TearDown]
    public void close_Browser()
    {
        driver.Quit();
    }

    public void closeLoginGoogle(IWebDriver driver)
    {
        IWebElement iframe = driver.FindElement(By.XPath("//iframe[@role='presentation']"));
        driver.SwitchTo().Frame(iframe);
        driver.FindElement(By.XPath("//button[text()='No acceder']")).Click();

        driver.SwitchTo().DefaultContent();
    }

    public void Click(IWebElement element)
    {
        element.Click();
    }

    public void SendText(IWebElement element, string value)
    {
        element.SendKeys(value);
    }
}