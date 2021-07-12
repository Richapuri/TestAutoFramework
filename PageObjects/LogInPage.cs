using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SwagLabs.PageObjects
{
    public class LogInPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement UserName { get; set; }


        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement LoginBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//h3[contains(text(),'Epic sadface')]")]
        public IWebElement LoginErrorMessage { get; set; }
        public LogInPage (IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public InventoryPage LogIn(string user_name, string pass_word)
        {
            UserName.SendKeys(user_name);
            Password.SendKeys(pass_word);
            LoginBtn.Submit();
            return new InventoryPage(driver);
        }
    }
}
