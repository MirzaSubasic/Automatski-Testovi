using OpenQA.Selenium;

namespace Automatski_Testovi.Pages
{
    public class CheckoutStepOnePage : BaseClass
    {
        CartPage cartPage;

        public CheckoutStepOnePage(IWebDriver driver) : base(driver)
        {
            cartPage = new CartPage(driver);
        }

        public void FillData(string firstName, string lastName, string postalCode)
        {
            cartPage.GoToCheckoutButtonClick();

            firstNameField.SendKeys(firstName);
            lastNameField.SendKeys(lastName);
            postalCodeField.SendKeys(postalCode);
        }

        public void ClickContiniueButton()
        {
            continiueButton.Click();
        }

        public string GetFirstName() { return firstNameField.Text; }

        public string GetLastName() { return lastNameField.Text; } 

        public string GetPostalCode() { return postalCodeField.Text; }
    }
}
