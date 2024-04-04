using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_tests;

class Exercise_BasicMaintenance
{
    IWebDriver driver;
    
    public IWebDriver SetUpDriver()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        return driver;
    }
    
    public void Click(IWebElement element)
    {
        element.Click();
    }

    public void SendText(IWebElement element, string value)
    {
        element.SendKeys(value);
    }

    #region Google Locators
    By GoogleSearchBar = By.XPath("need maintenance");
    By GoogleSearIcon = By.XPath("need maintenance");
    By UnoSquareGoogleResult = By.XPath("need maintenance");
    #endregion

    #region UnoSquare Locators
    By UnoSquareServicesMenu = By.XPath("need maintenance");
    By PracticeAreas = By.XPath("need maintenance");
    By ContactUs = By.XPath("need maintenance");
    #endregion 
    
    static void Main(string[] args)
    {
        IWebDriver Browser;
        IWebElement element;
        Program program = new Program();
        Browser = program.SetUpDriver();
        Browser.Url = "https://www.google.com";

        element = Browser.FindElement(program.GoogleSearchBar);

        program.SendText(element, "Unosquare");

        element = Browser.FindElement(program.GoogleSearIcon);

        program.Click(element);

        element = Browser.FindElement(program.UnoSquareGoogleResult);

        program.Click(element);

        element = Browser.FindElement(program.UnoSquareServicesMenu);

        program.Click(element);

        element = Browser.FindElement(program.PracticeAreas);

        program.Click(element);

        element = Browser.FindElement(program.ContactUs);

        program.Click(element);
    
    }
}