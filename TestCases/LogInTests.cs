using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework.Internal;
using NUnit.Framework;
using SwagLabs.PageObjects;
using System.Threading;

namespace SwagLabs.TestCases
{
    public class LogInTests
    {
        public IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void Initialize()
        {
            
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void LoginTestCorrectUserNameandPassword()
        {
            var login = new LogInPage(driver);
            login.LogIn("standard_user", "secret_sauce");
            Thread.Sleep(1000);
            Assert.AreEqual(driver.Title, "Swag Labs");
        }

        [Test]

        public void LoginTestIncorrectUsername()
        {
            var login = new LogInPage(driver);
            login.LogIn("standard_use", "secret_sauce");
            Thread.Sleep(1000);
            Assert.AreEqual(login.LoginErrorMessage.Text, "Epic sadface: Username and password do not match any user in this service");
        }

        [Test]
        public void LoginTestIncorrectPassword()
        {
            var login = new LogInPage(driver);
            login.LogIn("standard_user", "secret_sauc");
            Thread.Sleep(1000);
            Assert.AreEqual(login.LoginErrorMessage.Text, "Epic sadface: Username and password do not match any user in this service");
        }

        [Test]
        public void LoginTestIncorrectUserNameandPassword()
        {
            var login = new LogInPage(driver);
            login.LogIn("standard_use", "secret_sauc");
            Thread.Sleep(1000);
            Assert.AreEqual(login.LoginErrorMessage.Text, "Epic sadface: Username and password do not match any user in this service");
        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        }
    }
}
