using OpenQA.Selenium;

namespace Automatski_Testovi.Pages
{
    public class CheckoutCompletePage : BaseClass
    {
        CheckoutStepOnePage checkout;
        CheckoutStepTwoPage checkout1;

        public CheckoutCompletePage(IWebDriver driver) : base(driver)
        {
            checkout = new CheckoutStepOnePage(driver);
            checkout1 = new CheckoutStepTwoPage(driver);
        }

        public void ClickBackToHomeButton()
        {
            //Zbog log outa nakon svakog testa mora se pokrenuti proces iz pocetka
            checkout.FillData(staticData.FirstName, staticData.LastName, staticData.PostalCode);
            checkout.ClickContiniueButton();
            checkout1.ClickFinishButton();

            backToHomeButton.Click();
        }
    }
}
