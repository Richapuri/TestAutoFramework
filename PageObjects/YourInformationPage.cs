using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SwagLabs.PageObjects
{
    public class YourInformationPage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "first-name")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "last-name")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "postal-code")]
        public IWebElement PostCode { get; set; }

        [FindsBy(How = How.Id, Using = "continue")]
        public IWebElement ContinueBtn { get; set; }

        [FindsBy(How = How.Id, Using = "cancel")]
        public IWebElement CancelBtn { get; set; }

        public YourInformationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void EnterFirstName(string FirstNametxt) => FirstName.SendKeys(FirstNametxt);

        public void EnterLastName(string LastNametxt) => LastName.SendKeys(LastNametxt);

        public void EnterPostCode(string PostCodetxt) => PostCode.SendKeys(PostCodetxt);

        public void ClickOnCancelBtn() => CancelBtn.Click();

        public CheckOutOverviewPage ClickOnContinueBtn() 
        {
            ContinueBtn.Click();
            return new CheckOutOverviewPage(driver);
        }

    }
}
