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
        HomePageObjects HomePage;
        ProductPageObjects Products;

        [SetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
            HomePage = new HomePageObjects(_driver);
            Products = new ProductPageObjects(_driver);
            HomePage.goToPage();
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
            HomePage.testSearch(product);
            Assert.AreEqual(product + " - Search - IKEA", Products.getPageTitle());
        }

    }
}
