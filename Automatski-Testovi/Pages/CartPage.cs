using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automatski_Testovi.Pages
{
    public class CartPage : CommonElements
    {

        [FindsBy(How = How.XPath, Using = "//button[@class=\"btn btn_secondary btn_small cart_button\"]")]
        public IWebElement getRemoveButtonInCart;

        [FindsBy(How = How.Id, Using = "checkout")]
        public IWebElement checkoutButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='inventory_item_name']")]
        private IWebElement itemInCartName;

        public CartPage(IWebDriver driver) : base(driver) 
        {
        }

        public void GoToCheckoutButtonClick()
        {
            checkoutButton.Click();
        }

        public string GetItemInCartName()
        {
            return itemInCartName.Text;
        }
    }
}
