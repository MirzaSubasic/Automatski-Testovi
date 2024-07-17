using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automatski_Testovi.Pages
{
    public class LoginPage : CommonElements
    {

        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement usernameField;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement passwordField => driver.FindElement(By.Id("password"));

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement loginButton => driver.FindElement(By.Id("login-button"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }


        public void LogIn(string UserName, string password)
        {
            usernameField.SendKeys(UserName);
            passwordField.SendKeys(password);
            loginButton.Click();
        }

    }
}
