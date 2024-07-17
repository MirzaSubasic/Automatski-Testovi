using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automatski_Testovi.Pages
{
    public class CartPage : CommonElements
    {

        [FindsBy(How = How.XPath, Using = "//*[@class=\"btn btn_secondary btn_small cart_button\"]")]
        public IWebElement getRemoveButtonInCart;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"remove-sauce-labs-backpack\"]")]
        public IWebElement removeBackpackFromCartButton;

        [FindsBy(How = How.Id, Using = "checkout")]
        public IWebElement checkoutButton;

        LoginPage loginPage;
        InventoryPage inventoryPage;

        public CartPage(IWebDriver driver) : base(driver) 
        {
            inventoryPage = new InventoryPage(driver);
            loginPage = new LoginPage(driver);
        }

        private void GetPreviousSteps()
        {
            loginPage.LogIn(staticData.StandardUser, staticData.Password);
            inventoryPage.AddBackpackToCart();
            inventoryPage.GoToCartBadgeClick();
        }

        public string FindRemoveButtonText()
        {
            GetPreviousSteps();
            return removeBackpackFromCartButton.Text;
        }

        public void GoToCheckoutButtonClick()
        {
            GetPreviousSteps();
            checkoutButton.Click();
        }
    }
}
