using OpenQA.Selenium;

namespace Automatski_Testovi.Pages
{
    public class LoginPage : BaseClass
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private void EnterLoginCredentials(string UserName, string password)
        {
            usernameField.SendKeys(UserName);
            passwordField.SendKeys(password);
        }

        private void ClickLoginButton()
        {
            loginButton.Click();
        }

        public void LogIn(string UserName, string password)
        {
            driver.Navigate().GoToUrl(staticData.LoginURL);
            EnterLoginCredentials(staticData.StandardUser, staticData.Password);
            ClickLoginButton();
        }

    }
}
