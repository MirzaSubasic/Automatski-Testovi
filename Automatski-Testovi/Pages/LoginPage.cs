using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automatski_Testovi.Pages
{
    public class LoginPage : BaseClass
    {
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private void EnterLoginCredentials(string UserName, string password)
        {
            UsernameField.SendKeys(UserName);
            PasswordField.SendKeys(password);
        }

        private void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void LogIn(string UserName, string password)
        {
            driver.Navigate().GoToUrl(staticData.LoginURL);
            EnterLoginCredentials(staticData.StandardUser, staticData.Password);
            ClickLoginButton();

        }

    }
}
