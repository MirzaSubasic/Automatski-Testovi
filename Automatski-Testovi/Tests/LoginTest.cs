using OpenQA.Selenium.Support.UI;

namespace Automatski_Testovi.Tests
{
    public class LoginTest : DriversSetup
    {

        [Test]
        public void TestLoadingOfLoginPage()
        {
            driver.Navigate().GoToUrl(staticData.LoginURL);
            Assert.That(driver.Title, Does.Contain("Swag Labs"));
        }

        [Test]
        public void TestLoginFinctionality()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            loginPage.LogIn(staticData.StandardUser, staticData.Password);

            Assert.That(driver.Url, Does.Contain(staticData.InventoryURL));
        }
    }
}
