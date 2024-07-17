using OpenQA.Selenium;

namespace Automatski_Testovi.Pages
{
    public class CartPage : BaseClass
    {
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
