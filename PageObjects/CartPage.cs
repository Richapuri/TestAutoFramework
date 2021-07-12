using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SwagLabs.PageObjects
{
    public class CartPage
    {
        IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "checkout")]
        private IWebElement CheckOutBtn { get; set; }

        [FindsBy(How = How.Id, Using = "continue-shopping")]
        public IWebElement ContinueShoppingBtn { get; set; }

        public YourInformationPage ClickOnCheckOutBtn()
        {
            CheckOutBtn.Click();
            return new YourInformationPage(driver);
        }

        public void ClickOnContinueShoppingBtn() => ContinueShoppingBtn.Click();

        public IWebElement CartItems(string ItemTxt)
        {
            string ItemText = "//div[@class='inventory_item_name' and text() = '" + ItemTxt + "']";
            return driver.FindElement(By.XPath(ItemText));
        }

    }
}