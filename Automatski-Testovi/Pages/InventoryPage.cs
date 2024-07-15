using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Automatski_Testovi.Pages
{
    internal class InventoryPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement cartBadge => driver.FindElement(By.ClassName("shopping_cart_badge"));
        private IReadOnlyCollection<IWebElement> inventory => driver.FindElements(By.ClassName("inventory_item"));

        public void AddBackpackToCart() 
        {
            //AddBackpackToCartButton.Click();
            IReadOnlyCollection<IWebElement> products = driver.FindElements(By.XPath("//*[@id=\"inventory_container\"]"));
            foreach (IWebElement product in products) 
            {
                product.FindElement(By.ClassName("add-to-cart-sauce-labs-backpack")).Click();
                break;
            }
        }

        public string VerifyTextForRemoveFromCartButton()
        {
            IReadOnlyCollection<IWebElement> products = driver.FindElements(By.XPath("//*[@id=\"inventory_container\"]"));
            foreach (IWebElement product in products)
            {
                return product.FindElement(By.ClassName("remove-sauce-labs-backpack")).Text;
            }
            return "";
        }

        public void GoToCart() 
        {
            cartBadge.Click();
        }

        public IReadOnlyCollection<IWebElement> GetElements()
        {
            return inventory;
        }
    }
}
