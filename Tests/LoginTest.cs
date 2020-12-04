using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
//using POMExample.PageObjects;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;
using InterviewTest.PageObjects;

namespace InterviewTest.Tests
{
    // [TestClass]
    public class LoginTest
    {
        IWebDriver _driver;
        HomePageObjects HomePage;
        LoginPageObjects LoginPage;

        [SetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
            HomePage = new HomePageObjects(_driver);
            LoginPage = new LoginPageObjects(_driver);

            HomePage.goToPage();
            HomePage.OpenProfile();
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Close();
            _driver.Quit();
        }

        [Test]
        public void FindLoginPage()
        {
            HomePage.SignIn();
            Assert.AreEqual("Login - IKEA", LoginPage.getPageTitle());
        }
    }
}
