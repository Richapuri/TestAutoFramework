using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SwagLabs.PageObjects
{
    public class CheckOutCompletePage
    {
        IWebDriver driver;
        public CheckOutCompletePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h2[text() = 'THANK YOU FOR YOUR ORDER']")]
        private IWebElement ThankYouHeading { get; set; }

        

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Back Home']")]
        private IWebElement BackHomeBtn { get; set; }

        public string ThankYouHeadingMessage()
        {
            return ThankYouHeading.Text;
        }

        public CheckOutCompletePage ClickOnBackHomeBtn()
        {
            BackHomeBtn.Click();
            return new CheckOutCompletePage(driver);
        }


    }
}
