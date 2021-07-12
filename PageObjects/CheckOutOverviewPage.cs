using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SwagLabs.PageObjects
{
    public class CheckOutOverviewPage
    {
        IWebDriver driver;
        public CheckOutOverviewPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Finish']")]
        public IWebElement FinishBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Cancel']")]
        public IWebElement CancelBtn { get; set; }

        public IWebElement ItemInCart(string ItemName)
        {
            return driver.FindElement(By.XPath("//div[@class = 'inventory_item_name' and text() = '" + ItemName + "']"));
        }

        public string PriceOfItemInCart(string ItemName)
        {
            return driver.FindElement(By.XPath("//div[@class='inventory_item_name' and text() = '" + ItemName + "']//following::div[2]//div")).Text;
        }

        public CheckOutCompletePage ClickOnFinishBtn()
        {
            FinishBtn.Click();
            return new CheckOutCompletePage(driver);
    }   }
}
