using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Automatski_Testovi.Pages
{
    public class InventoryPage : BaseClass
    {
        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void AddBackpackToCart()
        {
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
