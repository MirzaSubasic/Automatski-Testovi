using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatski_Testovi.Pages
{
    internal class InventoryPage
    {
        private IWebDriver driver;

        public InventoryPage(IWebDriver driver)
        {  
            this.driver = driver;
        }
        
        private IWebElement AddBackpackToCartButton => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement RemoveBackpackFromCartButton => driver.FindElement(By.Id("remove-sauce-labs-backpack"));
        private IWebElement CartBadge => driver.FindElement(By.ClassName("shopping_cart_badge"));

        public void AddBackpackToCart() 
        {
            AddBackpackToCartButton.Click();
        }

        public string VerifyTextForRemoveFromCartButton()
        { 
            return RemoveBackpackFromCartButton.Text;
        }

        public void GoToCart() 
        {
            CartBadge.Click();
        }
    }
}
