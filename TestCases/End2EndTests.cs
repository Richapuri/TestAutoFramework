using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SwagLabs.PageObjects;
using System.Threading;

namespace SwagLabs.TestCases
{
    class End2EndTests
    {
        public IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void Initialise()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void BuyAnItemTest()
        {
            var login = new LogInPage(driver);
            var inv = login.LogIn("standard_user", "secret_sauce");
            Thread.Sleep(2000);
            inv.AddToCartBtnByItemName(@"Test.allTheThings() T-Shirt (Red)").Click();
            Thread.Sleep(2000);
            var cartpg = inv.ClickOnShoppingCartBadge();
            Thread.Sleep(2000);
            var yourinformationpg = cartpg.ClickOnCheckOutBtn();
            Thread.Sleep(2000);
            yourinformationpg.EnterFirstName("James");
            yourinformationpg.EnterLastName("Smith");
            yourinformationpg.EnterPostCode("1234");
            var checkoutoverviewpg = yourinformationpg.ClickOnContinueBtn();
            Thread.Sleep(2000);
            Assert.AreEqual(checkoutoverviewpg.ItemInCart("Test.allTheThings() T-Shirt (Red)").Text, "Test.allTheThings() T-Shirt (Red)");
            Assert.AreEqual(checkoutoverviewpg.PriceOfItemInCart("Test.allTheThings() T-Shirt (Red)"), "$15.99");
            var checkoutcompletepg = checkoutoverviewpg.ClickOnFinishBtn();
            Thread.Sleep(2000);
            Assert.IsNotEmpty(checkoutcompletepg.ThankYouHeadingMessage());
        }

    }
}
