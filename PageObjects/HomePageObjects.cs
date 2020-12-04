using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;

namespace InterviewTest.PageObjects
{
    class HomePageObjects
    {
        String test_url = "https://www.ikea.com/us/en";

        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePageObjects(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //PageFactory.InitElements(driver, this);
        }

        // Page Elements
        private IWebElement SearchBox => driver.FindElement(By.ClassName("search-box"));
        private IWebElement SearchInput => driver.FindElement(By.ClassName("search-field__input"));
        private IWebElement SearchButton => driver.FindElement(By.Id("search-box__searchbutton"));
        private IWebElement ProfileButton => driver.FindElement(By.ClassName("hnf-header__profile-link"));
        private IWebElement LoyaltyHeader => driver.FindElement(By.ClassName("loyalty-modal-content__link-page__header-title"));
        private IWebElement SignInButton => driver.FindElement(By.LinkText("Sign in"));

        // Go to the designated page
        public void goToPage()
        {
            driver.Navigate().GoToUrl(test_url);
        }

        // Returns the Page Title
        public String getPageTitle()
        {
            return driver.Title;
        }

        public HomePageObjects testSearch(string inputSearch)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("search-field__input")));
            SearchBox.Click();
            SearchInput.SendKeys(inputSearch);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("search-box__searchbutton")));
            SearchButton.Click();
            return new HomePageObjects(driver);
        }

        public void OpenProfile()
        {
            ProfileButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Sign in")));
            //The following won't work:
            //Error	CS1503	Argument 1: cannot convert from 'OpenQA.Selenium.IWebElement' to 'OpenQA.Selenium.By
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(el));
        }

        public string GetLoyaltyHeader()
        {
            return LoyaltyHeader.Text;
        }

        public string SignInText()
        {
            return SignInButton.Text;
        }

        public void SignIn()
        {
            SignInButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("username")));
        }
    }
}
