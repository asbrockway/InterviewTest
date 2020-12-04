﻿using System;
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
    public class HomePageTest
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
        public void FindHomePage()
        {
            HomePageObjects HomePage = new HomePageObjects(_driver);
            HomePage.goToPage();
            Assert.AreEqual("IKEA US - Furniture and Home Furnishings - IKEA", HomePage.getPageTitle());
        }

        [Test]
        public void GetProfile()
        {
            HomePageObjects HomePage = new HomePageObjects(_driver);
            HomePage.goToPage();
            HomePage.OpenProfile();
            Assert.AreEqual("Hej!", HomePage.GetLoyaltyHeader());
            Assert.AreEqual("Sign in", HomePage.SignInText());
        }
    }
}
