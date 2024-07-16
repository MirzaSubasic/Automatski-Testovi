using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Automatski_Testovi.Pages;
using OpenQA.Selenium.Support.UI;
using Automatski_Testovi.Static_elements;

namespace Automatski_Testovi.Tests
{
    [TestFixture]
    public class Tests: DriversSetup
    {

        [Test]
        public void VerifyInventoryItems()
        {
            loginPage.LogIn(staticData.StandardUser, staticData.Password);

            var items = inventoryPage.GetElements();

            Assert.That(items.Count, Is.EqualTo(6));

        }

        [Test]
        public void TestAddToCart()
        {
            loginPage.LogIn(staticData.StandardUser, staticData.Password);

            inventoryPage.AddBackpackToCart();

            string buttonText = inventoryPage.VerifyTextForRemoveFromCartButton();

            Assert.That(buttonText, Does.Contain("Remove"));
        }

        [Test]
        public void GoToCart() 
        {
            loginPage.LogIn(staticData.StandardUser, staticData.Password);

            inventoryPage.GoToCartBadgeClick();

            Assert.That(driver.Url, Does.Contain(staticData.CartUrl));
        }

    }
}
