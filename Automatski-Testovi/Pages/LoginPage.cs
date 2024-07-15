using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automatski_Testovi.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement UsernameField;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement PasswordField => driver.FindElement(By.Id("password"));
        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement LoginButton => driver.FindElement(By.Id("login-button"));

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void EnterLoginCredentials(string UserName, string password)
        {
            UsernameField.SendKeys(UserName);
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

    }
}
