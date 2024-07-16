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
