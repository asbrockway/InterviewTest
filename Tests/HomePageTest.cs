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
using OpenQA.Selenium.Chrome;
using InterviewTest.PageObjects;

namespace InterviewTest.Tests
{
    // [TestClass]
    public class HomePageTest
    {
        IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            // new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }

        [Test]
        public void FindHomePage()
        {
            HomePageObjects HomePage = new HomePageObjects(_driver);
            HomePage.goToPage();
            Assert.AreEqual("IKEA US - Furniture and Home Furnishings - IKEA", HomePage.getPageTitle());
        }

    }
}
