using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automatski_Testovi.Pages
{
    public class CheckoutStepTwoPage : CommonElements
    {

        [FindsBy(How = How.XPath, Using = "//button[@id='finish']")]
        public IWebElement finishOrderButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='summary_total_label']")]
        public IWebElement getTotalPrice;

        public CheckoutStepTwoPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickFinishButton()
        {
            finishOrderButton.Click();
        }

        public string GetTotalPrice()
        {
            return getTotalPrice.Text;
        }
    }
}
