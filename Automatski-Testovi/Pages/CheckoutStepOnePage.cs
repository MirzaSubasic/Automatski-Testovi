using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automatski_Testovi.Pages
{
    public class CheckoutStepOnePage : CommonElements
    {

        [FindsBy(How = How.Id, Using = "first-name")]
        public IWebElement firstNameField;

        [FindsBy(How = How.Id, Using = "last-name")]
        public IWebElement lastNameField;

        [FindsBy(How = How.Id, Using = "postal-code")]
        public IWebElement postalCodeField;

        [FindsBy(How = How.Id, Using = "continue")]
        public IWebElement continiueButton;

        public CheckoutStepOnePage(IWebDriver driver) : base(driver)
        {
        }

        public void FillData(string firstName, string lastName, string postalCode)
        {
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
