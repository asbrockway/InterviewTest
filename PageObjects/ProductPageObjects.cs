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
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;

namespace InterviewTest.PageObjects
{
    class ProductPageObjects
    {        
        private IWebDriver driver;
        private WebDriverWait wait;

        public ProductPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }        

        [FindsBy(How = How.ClassName, Using = "search-summary__heading")]
        [CacheLookup]
        private IWebElement elSearchSummaryHeading;
        
        // Returns the Page Title
        public String getPageTitle()
        {
            return driver.Title;
        }

        public string getProductSummary()
        {
            return elSearchSummaryHeading.Text;
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
