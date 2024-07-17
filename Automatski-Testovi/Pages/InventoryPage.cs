using OpenQA.Selenium;

namespace Automatski_Testovi.Pages
{
    public class InventoryPage : BaseClass
    {
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
