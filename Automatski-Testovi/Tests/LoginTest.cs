
namespace Automatski_Testovi.Tests
{
    public class LoginTest : BaseClass
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
            loginPage.LogIn(staticData.StandardUser, staticData.Password);

            Assert.That(driver.Url, Does.Contain(staticData.InventoryURL));
        }

    }
}
