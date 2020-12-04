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
        }    
        private IWebElement SearchSummaryHeading => driver.FindElement(By.ClassName("search-summary__heading"));
        
        // Returns the Page Title
        public String getPageTitle()
        {
            return driver.Title;
        }

        public string getProductSummary()
        {
            return SearchSummaryHeading.Text;
        }
    }
}
