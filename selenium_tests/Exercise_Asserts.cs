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

public class Exercise_Asserts
{
    IWebDriver driver;

    #region Google Locators
    By GoogleSearchBar = By.XPath("//textarea[@title='Buscar']");
    By UnoSquareGoogleRecommendation = By.XPath("//li[@data-entityname='unosquare']");
    By UnoSquareGoogleResult = By.XPath("//h3[text()='Unosquare: Home Page - Smart Engineering For Your Digital ...']");
    #endregion
    
    #region UnoSquare Locators
    By UnoSquareServicesMenu = By.XPath("//a[text()='Services']");
    By PracticeAreas = By.XPath("//a[text()='Industries']");
    By ContactUs = By.XPath("//span[text()='Contact Us']");
    #endregion
    
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
        IWebElement element;
        driver.Navigate().GoToUrl("https://www.google.com");
        closeLoginGoogle(driver);

        // Write the locator for the Google Search Bar
        element = driver.FindElement(GoogleSearchBar);

        // Write Assert True that element is present Google Search Bar
        ClassicAssert.IsTrue(element.Displayed);

        // Send the text "Unosquare" to the Text Bar
        SendText(element, "Unosquare");

        // Click on the first recommendation result
        Click(driver.FindElement(UnoSquareGoogleRecommendation));

        // Write Assert Equal [Unosquare: Digital Transformation Services | Agile Staffing ...] vs [Element.text]
        ClassicAssert.AreEqual("Unosquare: Home Page - Smart Engineering For Your Digital ...",
        driver.FindElements(UnoSquareGoogleResult)[0].Text);

        // Locate the first result corresponding to Unosquare and click on the Link
        Click(driver.FindElements(UnoSquareGoogleResult)[0]);

        // Write Assert True that element is present menu page
        ClassicAssert.IsTrue(driver.FindElement(By.XPath("//div[contains(@class, 'elementor-element-e751f71')]")).Displayed);

        // Write Assert True that element is present [Join Us] button
        ClassicAssert.IsTrue(driver.FindElement(By.XPath("//div[contains(@class, 'elementor-element-2cdfa08')]")).Displayed);

        // Write Assert Equal [Smart Engineering For Your Digital Solutions] vs [Element.text] h2 ojbect
        ClassicAssert.AreEqual("Smart Engineering\nFor Your Digital Solutions",
        driver.FindElement(By.XPath("//span[@class='blue-text']//parent::h1")).Text);

        // Locate the Service Menu and Click the element
        Click(driver.FindElements(UnoSquareServicesMenu)[1]);
        ClassicAssert.AreEqual(driver.Url, "https://www.unosquare.com/services/");

        // Locate the Practice Areas Menu and Click the Element
        Click(driver.FindElements(PracticeAreas)[1]);
        ClassicAssert.AreEqual(driver.Url, "https://www.unosquare.com/industries/");

        // Locate the Contact Us Menu and Click the Element
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