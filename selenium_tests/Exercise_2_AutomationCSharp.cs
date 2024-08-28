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

namespace selenium_tests {
    public class Exercise_2_AutomationCSharp : BasePage
    {   
        By welcomeMessage = By.XPath("//h2[contains(text(),'Connect')]");
        By createAccountButton = By.XPath("//a[text()='Create new account']");
        By firstNameInput = By.XPath("//input[@name='firstname']");
        By lastNameInput = By.XPath("//input[@name='lastname']");
        By mobileNumberInput = By.XPath("//input[@name='reg_email__']");
        By newPassword = By.XPath("//input[@name='reg_passwd__']");
        By birthdayMonth = By.XPath("//select[@name='birthday_month']");
        By birthdayDay = By.XPath("//select[@name='birthday_day']");
        By birthdayYear = By.XPath("//select[@name='birthday_year']");
        By genderFemale = By.XPath("//input[@name='sex' and @value='1']");

        [SetUp]
        public void Initializer()
        {
            SetupDriver();
        }

        [Test]
        [Category("waits")]
        public void firstTestCase()
        {
            GoToPage("https://www.facebook.com/");

            BasePage myDriver = new BasePage();
            myDriver.DriverName = GetPageTitle();
            AssertText("Facebook - log in or sign up", myDriver.DriverName);
            
            Click(createAccountButton);
            
            EnterText(firstNameInput, "First name");
            Console.WriteLine("First name");

            EnterText(lastNameInput, "Last name");
            Console.WriteLine("Last name");

            string number = RandomNumber(10);
            EnterText(mobileNumberInput, number);
            Console.WriteLine(number);

            EnterText(newPassword, "NewPassword123$");
            Console.WriteLine("NewPassword123$");
            
            FillBirthdayDay(5, 10, 2004);
            
            SelectGender("female");
            
            AssertText("Connect with friends and the world around you on Facebook.", GetText(welcomeMessage));
        }
    
        [TearDown]
        public void Finalizer()
        {
            Close_Driver();
        }

        public void FillBirthdayDay(int month, int day, int year) 
        {
            SelectOption(birthdayMonth, month);
            SelectOption(birthdayDay, day);
            SelectOption(birthdayYear, year);
        }

        public void SelectGender(string gender)
        {
            By locator = null;
            switch (gender)
            {
                case "female":
                    locator = By.XPath("//input[@name='sex' and @value='1']");
                    Console.WriteLine("You select female option");
                    break;
                case "male":
                    locator = By.XPath("//input[@name='sex' and @value='2']");
                    Console.WriteLine("You select male option");
                    break;
                case "custom":
                    locator = By.XPath("//input[@name='sex' and @value='-1']");
                    Console.WriteLine("You select custom option");
                    break;
                default:
                    break;
            }

            Click(locator);
        }
    }
}