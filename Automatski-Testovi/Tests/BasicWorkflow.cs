using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Automatski_Testovi.Pages;
using OpenQA.Selenium.Support.UI;
using Automatski_Testovi.Static_elements;


namespace Automatski_Testovi.Tests
{
    public class Tests
    {
        private IWebDriver driver;
        private LoginPage? loginPage;
        private InventoryPage? inventoryPage;
        private StaticData? staticData = new StaticData();

        [OneTimeSetUp]
        public void Setup()
        {
            var chromedirectory = Directory.GetCurrentDirectory();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(chromedirectory, options);

            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
        }

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
            
            loginPage.EnterLoginCredentials(staticData.StandardUser, staticData.Password);
            loginPage.ClickLoginButton();

            Assert.That(driver.Url, Does.Contain(staticData.InventoryURL));
        }

        [Test]
        public void VerifyInventoryItems()
        {
            var items = inventoryPage.GetElements();
            Assert.That(items.Count, Is.EqualTo(6));
        }


        [Test]
        public void TestAddToCart()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            inventoryPage.AddBackpackToCart();

            string buttonText = inventoryPage.VerifyTextForRemoveFromCartButton();

            Assert.That(buttonText, Does.Contain("Remove"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver?.Dispose();
        }

    }
}
