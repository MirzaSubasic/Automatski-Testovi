using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automatski_Testovi.Pages
{
    public class CheckoutCompletePage : CommonElements
    {

        [FindsBy(How = How.Id, Using = "back-to-products")]
        public IWebElement backToHomeButton;

        public CheckoutCompletePage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickBackToHomeButton()
        {
            backToHomeButton.Click();
        }
    }
}
