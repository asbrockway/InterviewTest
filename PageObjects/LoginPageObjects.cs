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
    class LoginPageObjects
    {
        String test_url = "https://www.ikea.com/us/en";

        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        // Page Elements
        private IWebElement UserName => driver.FindElement(By.Id("username"));

        // Returns the Page Title
        public String getPageTitle()
        {
            return driver.Title;
        } 
    }
}
