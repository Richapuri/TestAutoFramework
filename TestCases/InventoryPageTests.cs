using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Framework;
using SwagLabs.PageObjects;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

namespace SwagLabs.TestCases
{
    class InventoryPageTests
    {
        public IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void Initialize()
        {

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
        }
        [Test]

        public void PrintAllItemsinList()
        {
            var login = new LogInPage(driver);
            var inv = login.LogIn("standard_user", "secret_sauce");
            //var inv = new InventoryPage(driver);
            foreach (var s in inv.GetAllItemText())
            {
                Console.WriteLine(s);
            }
        }

        [Test]
        public void PrintAnItem()
        {
            var login = new LogInPage(driver);
            var inv = login.LogIn("standard_user", "secret_sauce");
            //var inv = new InventoryPage(driver);
            Console.WriteLine(inv.GetAllItemText()[0]);
        }

        [Test]

        public void PrintAnItemfromItemName()
        {
            var login = new LogInPage(driver);
            var inv = login.LogIn("standard_user", "secret_sauce");
            //var inv = new InventoryPage(driver);
            Console.WriteLine(inv.GetItemName("Sauce Labs Bike Light").Text);
        }

        [Test]

        public void PrintAnItemPricefromItemName()
        {
            var login = new LogInPage(driver);
            login.LogIn("standard_user", "secret_sauce");
            var inv = new InventoryPage(driver);
            Console.WriteLine(inv.GetItemPrice("Test.allTheThings() T-Shirt (Red)").Text);
        }

        [Test]

        public void ClickOnAddToCartBtnforItemName()
        {
            var login = new LogInPage(driver);
            var inv = login.LogIn("standard_user", "secret_sauce");
            //var inv = new InventoryPage(driver);
            inv.AddToCartBtnByItemName(@"Test.allTheThings() T-Shirt (Red)").Click();
            var cartpg = inv.ClickOnShoppingCartBadge();
            cartpg.CartItems("Sauce Labs Backpack");
            //var cartpg = new CartPage(driver);
            Assert.AreEqual("Test.allTheThings() T-Shirt (Red)", cartpg.CartItems("Test.allTheThings() T-Shirt (Red)").Text);

        }

        [Test]

        public void Logout()
        {
            var login = new LogInPage(driver);
            var inv = login.LogIn("standard_user", "secret_sauce");
            inv.MenuBtn.Click();
            Thread.Sleep(2000);
            inv.LogoutBtn.Click();
            Assert.True(driver.PageSource.Contains("login-button"));

        }

        [Test]
        public void NavigateToAboutPage()
        {
            var login = new LogInPage(driver);
            var inv = login.LogIn("standard_user", "secret_sauce");
            inv.MenuBtn.Click();
            Thread.Sleep(2000);
            inv.AboutLink.Click();
            Thread.Sleep(2000);
            Assert.AreEqual("Cross Browser Testing, Selenium Testing, Mobile Testing | Sauce Labs", driver.Title);
        }

    }
}
