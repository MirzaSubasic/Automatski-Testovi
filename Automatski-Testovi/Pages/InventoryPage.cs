using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automatski_Testovi.Pages
{
    public class InventoryPage : CommonElements
    {
        [FindsBy(How = How.XPath, Using = "//a[@class=\"shopping_cart_link\"]")]
        public IWebElement cartBadge;

        [FindsBy(How = How.ClassName, Using = "inventory_item")]
        public IList<IWebElement> inventory;

        [FindsBy(How = How.XPath, Using = "//button[@id=\"add-to-cart-sauce-labs-backpack\"]")]
        public IWebElement addBackpackToCartButton;

        [FindsBy(How = How.XPath, Using = "//button[@id=\"remove-sauce-labs-backpack\"]")]
        public IWebElement removeBackpackFromCartButton;


        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }

        private void RemoveIfExists() 
        {
            try 
            {
                removeBackpackFromCartButton.Click();
            }
            catch 
            {
                Console.WriteLine("Nothing is selected");
            }
        }

        public void AddBackpackToCart()
        {
            //ako se desi da je element ostao odabran prvo ce probati da klikne Remove buton pa onda radi test za add to cart
            RemoveIfExists();
            addBackpackToCartButton.Click();
        }

        public string VerifyTextForRemoveFromCartButton()
        {
            return removeBackpackFromCartButton.Text;
        }

        public void GoToCartBadgeClick()
        {
            cartBadge.Click();
        }

        public IList<IWebElement> GetElements()
        {
            return inventory;
        }

        
    }
}
