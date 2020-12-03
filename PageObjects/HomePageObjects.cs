using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
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
        [FindsBy(How = How.ClassName, Using = "search-box")]
        [CacheLookup]
        private IWebElement elSearchBox;

        [FindsBy(How = How.ClassName, Using = "search-field__input")]
        [CacheLookup]
        private IWebElement elSearchInput;

        [FindsBy(How = How.Id, Using = "search-box__searchbutton")]
        [CacheLookup]
        private IWebElement elSearchButton;

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
            elSearchBox.Click();
            elSearchInput.SendKeys(inputSearch);
            elSearchButton.Click();
            return new HomePageObjects(driver);
        }
    }
}
