using OpenQA.Selenium;

namespace Automatski_Testovi.Pages
{
    public class CheckoutStepTwoPage : BaseClass
    {

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
