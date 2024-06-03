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

namespace selenium_tests;

public class Exercise_1_AutomationCSharp
{
    IWebDriver driver;

    #region Facebook Login Locators
    By welcomeMessage = By.XPath("//h2[contains(text(),'Connect')]");
    By createAccountButton = By.XPath("//a[text()='Create new account']");
    By firstNameInput = By.XPath("//input[@name='firstname']");
    By lastNameInput = By.XPath("//input[@name='lastname']");
    By mobileNumberInput = By.XPath("//input[@name='reg_email__']");
    By newPassword = By.XPath("//input[@name='reg_passwd__']");
    By birthdayMonth = By.XPath("//select[@name='birthday_month']");
    By birthdayDay = By.XPath("//select[@name='birthday_day']");
    By birthdayYear = By.XPath("//select[@name='birthday_year']");
    By genderMale = By.XPath("//input[@name='sex' and @value='2']");
    By submitButton = By.XPath("//button[@name='websubmit']");
    By inexistenElement = By.XPath("//*[@name='iamnotexists']");
    #endregion

    #region Facebook Policies Locators
    By termsLink = By.XPath("//a[@title='Review our terms and policies.']");
    By termsText = By.XPath("//h4[text()='Terms of Service']");
    By termsTitle = By.XPath("//h2[text()='Terms of Service']");
    By leftMenuElement1 = By.XPath("//a[text()=' 1. The services we provide ']");
    By leftMenuElement2 = By.XPath("//a[text()=' 2. How our services are funded ']");
    By leftMenuElement3 = By.XPath("//a[text()=' 3. Your commitments to Facebook and our community ']");
    By leftMenuElement4 = By.XPath("//a[text()=' 4. Additional provisions ']");
    By leftMenuElement5 = By.XPath("//a[text()=' 5. Other terms and policies that may apply to you ']");
    By menuBoxElement1 = By.XPath("//div[@class='_5tko _52ye _3m9']/div[2]/a[1]//div//div");
    By menuBoxElement2 = By.XPath("//div[@class='_5tko _52ye _3m9']/div[2]/a[2]//div//div");
    By menuBoxElement3 = By.XPath("//div[@class='_5tko _52ye _3m9']/div[2]/a[3]//div//div");
    By menuBoxElement4 = By.XPath("//div[@class='_5tko _52ye _3m9']/div[2]/a[4]//div//div");
    By menuBoxElement5 = By.XPath("//div[@class='_5tko _52ye _3m9']/div[2]/a[5]//div//div");
    By menuBoxElement6 = By.XPath("//div[@class='_5tko _52ye _3m9']/div[2]/div//div//div");
    By menuBoxElement7 = By.XPath("//div[@class='_5tko _52ye _3m9']/div[2]/div//ul//li//a");
    #endregion
        
    [SetUp]
    public void SetUpDriver()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        driver.Navigate().GoToUrl("https://www.facebook.com/");
    }
        
    [Test]
    [Category("login")]
    public void firstTestCase()
    {
        ClassicAssert.AreEqual("Connect with friends and the world around you on Facebook.", GetText(welcomeMessage));
            
        Click(createAccountButton);
            
        EnterText(firstNameInput, "First name");
        EnterText(lastNameInput, "Last name");
        EnterText(mobileNumberInput, RandomNumber(10));
        EnterText(newPassword, "NewPassword123$");
            
        SelectOption(birthdayMonth, 1);
        SelectOption(birthdayDay, 1);
        SelectOption(birthdayYear, 2000);
            
        Click(genderMale);
            
        FindOneElement(inexistenElement);
    }
        
    [Test]
    [Category("policies")]
    public void secondTestCase()
    {
        Click(termsLink);
        Click(termsText);

        ChangeToNewTab();

        IsDisplayed(termsTitle);
        IsDisplayed(leftMenuElement1);
        IsDisplayed(leftMenuElement2);
        IsDisplayed(leftMenuElement3);
        IsDisplayed(leftMenuElement4);
        IsDisplayed(leftMenuElement5);

        for (int i = 1; i <= 7; i++)
        {
            Console.WriteLine(CreateList()[i-1]);
        }
    }
        
    [TearDown]
    public void close_Browser()
    {
        driver.Quit();
    }
        
    public IWebElement FindOneElement(By locator)
    {
        IWebElement element = null;

        try
        {
            element = driver.FindElement(locator);
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

    public bool IsDisplayed(By locator)
    {
        return FindOneElement(locator).Displayed;
    }
        
    public string GetText(By locator)
    {
        return FindOneElement(locator).Text;
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

    public void ChangeToNewTab()
    {
        driver.SwitchTo().Window(driver.WindowHandles.Last());
    }
        
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

    public List<string> CreateList()
    {
        List<string> menuElements = new List<string>();
        for (int i = 1; i <= 7; i++)
        {
            switch(i)
            {
                case 1:
                    menuElements.Add(GetText(menuBoxElement1));
                    break;
                case 2:
                    menuElements.Add(GetText(menuBoxElement2));
                    break;
                case 3:
                    menuElements.Add(GetText(menuBoxElement3));
                    break;
                case 4:
                    menuElements.Add(GetText(menuBoxElement4));
                    break;
                case 5:
                    menuElements.Add(GetText(menuBoxElement5));
                    break;
                case 6:
                    menuElements.Add(GetText(menuBoxElement6));
                    break;
                case 7:
                    menuElements.Add(GetText(menuBoxElement7));
                    break;
                default:
                    break;
            }
        }
        return menuElements;
    }
}