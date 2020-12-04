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
            PageFactory.InitElements(driver, this);
        }

        // Page Elements
        private IWebElement SearchBox => driver.FindElement(By.ClassName("search-box"));

        //[FindsBy(How = How.ClassName, Using = "search-field__input")]
        //[CacheLookup]
        private IWebElement SearchInput => driver.FindElement(By.ClassName("search-field__input"));

        //[FindsBy(How = How.Id, Using = "search-box__searchbutton")]
        //[CacheLookup]
        private IWebElement SearchButton => driver.FindElement(By.ClassName("search-box__searchbutton"));

        [FindsBy(How = How.ClassName, Using = "hnf-header__profile-link")]
        [CacheLookup]
        private IWebElement elProfileButton;

        [FindsBy(How = How.ClassName, Using = "loyalty-modal-content__link-page__header-title")]
        [CacheLookup]
        private IWebElement elLoyaltyHeader;

        //private IWebElement elSignIn => driver.FindElements(By.ClassName("link")).First();
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

        // Returns the search string
        //public String getSearchText()
        //{
        //    return elem_search_text.Text;
        //}

        // Checks whether the Logo is displayed properly or not
        //public bool getWebPageLogo()
        //{
        //    return elem_logo_img.Displayed;
        //}

        public HomePageObjects testSearch(string inputSearch)
        {
            SearchBox.Click();
            SearchInput.SendKeys(inputSearch);
            SearchButton.Click();
            return new HomePageObjects(driver);
        }

        public void OpenProfile()
        {
            IWebElement el = elLoyaltyHeader;
            elProfileButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Sign in")));
            //The following won't work:
            //Error	CS1503	Argument 1: cannot convert from 'OpenQA.Selenium.IWebElement' to 'OpenQA.Selenium.By
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(el));
        }

        public string GetLoyaltyHeader()
        {
            return elLoyaltyHeader.Text;
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
