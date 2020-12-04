using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
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
        string username;
        string password;
        string member;

        [SetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
            HomePage = new HomePageObjects(_driver);
            LoginPage = new LoginPageObjects(_driver);

            username = "testy@mytopn.net";
            password = "j8#/MYTKu.c!H3n";
            member = "Interview Test";

            HomePage.goToPage();
            HomePage.OpenProfile();
            HomePage.SignIn();
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
            Assert.AreEqual("Login - IKEA", LoginPage.getPageTitle());
        }

        [Test]
        public void LogInAndOut()
        {
            LoginPage.Login(username, password);
            Assert.AreEqual(member, LoginPage.GetMemberName());
            HomePage.OpenProfile();
            LoginPage.LogOut();
            HomePage.WaitForSearchField();
            Assert.AreEqual("IKEA US - Furniture and Home Furnishings - IKEA", HomePage.getPageTitle());
        }

        //[Test]
        //public void LogOut()
        //{
        //    LoginPage.Login(username, password);
        //    HomePage.OpenProfile();
        //    LoginPage.LogOut();
        //    HomePage.WaitForSearchField();
        //    Assert.AreEqual("IKEA US - Furniture and Home Furnishings - IKEA", HomePage.getPageTitle());
        //}
    }
}
