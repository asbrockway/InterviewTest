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
    class ProductPageObjects
    {
        String test_url = "https://www.ikea.com/us/en";

        private IWebDriver driver;
        private WebDriverWait wait;

        public ProductPageObjects(IWebDriver driver)
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

        [FindsBy(How = How.ClassName, Using = "search-summary__heading")]
        [CacheLookup]
        private IWebElement elSearchSummaryHeading;

        //[FindsBy(How = How.Name, Using = "q")]
        //[CacheLookup]
        //private IWebElement elem_search_text;

        //[FindsBy(How = How.Name, Using = "btnI")]
        //[CacheLookup]
        //private IWebElement elem_submit_button;

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

        //public SearchPage test_search(string input_search)
        //{
        //    elem_search_text.SendKeys(input_search);
        //    //wait.Until(ExpectedConditions.ElementToBeClickable(elem_submit_button)).Submit();
        //    elem_search_text.Submit();
        //    return new SearchPage(driver);
        //}
    }
}
