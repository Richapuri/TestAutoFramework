using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SwagLabs.PageObjects
{
    public class InventoryPage
    {

        private IWebDriver driver;
        [FindsBy(How = How.XPath, Using = "//button[@id='react-burger-menu-btn']")]
        public IWebElement MenuBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='about_sidebar_link']")]
        public IWebElement AboutLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='logout_sidebar_link']")]
        public IWebElement LogoutBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='shopping_cart_badge']")]
        private IWebElement ShoppingCartBadge { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'product_sort_container']")]
        private IWebElement SortDropDown { get; set; }

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string[] GetAllItemText()
        {
            List<string> AllItemsText = new List<string>();
            for (int i = 1; i <= 6; i++)
            {
                AllItemsText.Add(driver.FindElement(By.XPath("//div[@class = 'inventory_list']/child::div[" + i + "]//div[@class='inventory_item_name']")).Text);
            }
            return AllItemsText.ToArray();
        }

        public IWebElement GetItemName(string ItemText)
        {
            return driver.FindElement(By.XPath(@"//div[@class = 'inventory_item_name' and text() = '" + ItemText + "']"));
        }

        public IWebElement GetItemPrice(string ItemText)
        {
            return driver.FindElement(By.XPath("//div[@class='inventory_item_name' and text() = '" + ItemText + "']//following::div[@class='inventory_item_price']"));
        }

        public IWebElement AddToCartBtnByItemName(string ItemText) => driver.FindElement(By.Id("add-to-cart-" + ItemText.ToLower().Replace(" ", "-")));

        public void ClickOnAllItemsLink() => driver.FindElement(By.Id("inventory_sidebar_link")).Click();

        public void ClickOnAboutLink() => driver.FindElement(By.Id("about_sidebar_link")).Click();

        public void ClickOnLogOutLink() => driver.FindElement(By.Id("logout_sidebar_link")).Click();

        public void ClickOnResetAppLink() => driver.FindElement(By.Id("reset_sidebar_link")).Click();

        public CartPage ClickOnShoppingCartBadge()
        {
            ShoppingCartBadge.Click();
            return new CartPage(driver);
        }

        public void SortItemsDDL(string optiontxt)
        {
            SelectElement s = new SelectElement(SortDropDown);
            s.SelectByText(optiontxt);

        }

        //[FindsBy(How = How.Id, Using = "")]
        //private IWebElement AddtoCart { get; set; }
    }
}
