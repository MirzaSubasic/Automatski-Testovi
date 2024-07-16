using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CheckoutButton.Click();
        }
    }
}
