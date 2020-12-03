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
    public class ProductSearchTest
    {
        IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            // new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Close();
            _driver.Quit();
        }

        [Test]
        public void FindProduct()
        {
            string product = "Ivar";
            HomePageObjects HomePage = new HomePageObjects(_driver);
            HomePage.goToPage();
            HomePage.testSearch(product);
            ProductPageObjects Products = new ProductPageObjects(_driver); 
            Assert.AreEqual(product + " - Search - IKEA", Products.getPageTitle());
        }

    }
}
