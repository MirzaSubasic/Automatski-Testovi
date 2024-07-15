using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace Automatski_Testovi.Pages
{
    internal class InventoryPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [FindsBy(How = How.ClassName, Using = "shopping_cart_badge")]
        private IWebElement cartBadge;
        [FindsBy(How = How.ClassName, Using = "inventory_item")]
        private IList<IWebElement> inventory;

        public InventoryPage(IWebDriver driver)
            {
                this.driver = driver;
                PageFactory.InitElements(driver, this);
            }

        public void AddBackpackToCart()
        {
            IReadOnlyCollection<IWebElement> products = driver.FindElements(By.XPath("//*[@id=\"inventory_container\"]"));
            foreach (IWebElement product in products)
            {
                IWebElement addToCartButton = product.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div/div/div[1]/div[2]/div[2]/button"));

                addToCartButton.Click();
                break;
            }
        }

        public string VerifyTextForRemoveFromCartButton()
        {
            IReadOnlyCollection<IWebElement> products = driver.FindElements(By.XPath("//*[@id=\"inventory_container\"]/div"));
            foreach (IWebElement product in products)
            {
                IWebElement removeButton = product.FindElement(By.XPath("//*[@id=\"remove-sauce-labs-backpack\"]"));
                return removeButton.Text;
            }
            return "";
        }

        public void GoToCart() 
        {
            cartBadge.Click();
        }

        public IList<IWebElement> GetElements()
        {
            return inventory;
        }
    }
}
