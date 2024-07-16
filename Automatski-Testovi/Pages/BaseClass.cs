using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Automatski_Testovi.Static_elements;

namespace Automatski_Testovi.Pages
{
    public class BaseClass
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public StaticData staticData = new StaticData();

        protected BaseClass(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //LOGIN PAGE

        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement usernameField;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement passwordField => driver.FindElement(By.Id("password"));

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement loginButton => driver.FindElement(By.Id("login-button"));


        //INVENTORY / HOME PAGE

        [FindsBy(How = How.XPath, Using = "//*[@class=\"shopping_cart_link\"]")]
        public IWebElement cartBadge;

        [FindsBy(How = How.ClassName, Using = "inventory_item")]
        public IList<IWebElement> inventory;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"add-to-cart-sauce-labs-backpack\"]")]
        public IWebElement addBackpackToCartButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"remove-sauce-labs-backpack\"]")]
        public IWebElement removeBackpackFromCartButton;


        //CART

        [FindsBy(How = How.XPath, Using = "//*[@class=\"btn btn_secondary btn_small cart_button\"]")]
        public IWebElement getRemoveButtonInCart;

        [FindsBy(How = How.Id, Using = "checkout")]
        public IWebElement CheckoutButton;


        //CHECKOUT STEP INE

        [FindsBy(How = How.Id, Using = "first-name")]
        public IWebElement firstNameField;

        [FindsBy(How = How.Id, Using = "last-name")]
        public IWebElement lastNameField;

        [FindsBy(How = How.Id, Using = "postal-code")]
        public IWebElement postalCodeField;

        [FindsBy(How = How.Id, Using = "continue")]
        public IWebElement continiueButton;
    }
}
