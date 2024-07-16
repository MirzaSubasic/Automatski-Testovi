using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automatski_Testovi.Pages
{
    public class BaseClass
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        //LOGIN PAGE
        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement UsernameField;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordField => driver.FindElement(By.Id("password"));

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));

        //INVENTORY / HOME PAGE

        [FindsBy(How = How.Id, Using = "shopping_cart_link")]
        public IWebElement cartBadge;

        [FindsBy(How = How.ClassName, Using = "inventory_item")]
        public IList<IWebElement> inventory;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"add-to-cart-sauce-labs-backpack\"]")]
        public IWebElement addBackpackToCartButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"remove-sauce-labs-backpack\"]")]
        public IWebElement removeBackpackFromCartButton;
    }
}
