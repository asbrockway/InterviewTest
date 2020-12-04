using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;

namespace InterviewTest.PageObjects
{
    class LoginPageObjects
    {
        String test_url = "https://www.ikea.com/us/en";

        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        // Page Elements
        private IWebElement UserName => driver.FindElement(By.Id("username"));
        private IWebElement Password => driver.FindElement(By.Id("Password"));
        private IWebElement ContinueButton => driver.FindElement(By.ClassName("btn--transactional"));
        private IWebElement WelcomeWrapper => driver.FindElement(By.ClassName("welcome__text-wrapper"));
        private IWebElement MemberName => driver.FindElement(By.ClassName("loyalty-hub__qr-code__name"));
        private IWebElement LogOutButton => driver.FindElement(By.LinkText("Log out"));

        // Returns the Page Title
        public String getPageTitle()
        {
            return driver.Title;
        }
        
        public void Login(string user, string pass)
        {
            UserName.SendKeys(user);
            Password.SendKeys(pass);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("btn--transactional")));
            ContinueButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("welcome__text-wrapper")));
        }

        public string GetMemberName()
        {
            return MemberName.Text;
        }

        public void LogOut()
        {
            LogOutButton.Click();
        }
    }
}
