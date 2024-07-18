
using OpenQA.Selenium;

namespace Automatski_Testovi.Tests
{
    public class BuyBackpackTests: BaseClass
    {
        [Test]
        public void BuyBackpackTest()
        {
            //Učitati log in stranicu 
            driver.Navigate().GoToUrl(staticData.LoginURL);
            Assert.That(driver.Title, Does.Contain("Swag Labs"));

            //Uraditi log in
            loginPage.LogIn(staticData.StandardUser, staticData.Password);
            Assert.That(driver.Url, Does.Contain(staticData.InventoryURL));

            //Prikazan bar jedan element
            IList<IWebElement> items = inventoryPage.GetElements();
            Assert.That(items.Count, Is.Not.EqualTo(0));

            //Dodati ruksak u cart i provjeriti da se pojavilo Remove dugme
            inventoryPage.AddBackpackToCart();
            string buttonText = inventoryPage.VerifyTextForRemoveFromCartButton();
            Assert.That(buttonText, Does.Contain("Remove"));

            //Otići u cart
            inventoryPage.GoToCartBadgeClick();
            Assert.That(driver.Url, Does.Contain(staticData.CartUrl));

            //Provjeriti ime itema u cartu
            string itemInCartName = cartPage?.GetItemInCartName();
            Assert.That(itemInCartName, Does.Contain("Sauce Labs Backpack"));

            //Kliknuti checkout i provjeriti je li se učitala stranica
            cartPage.GoToCheckoutButtonClick();
            Assert.That(driver.Url, Does.Contain(staticData.CheckoutUrl));

            //Popunii podatke
            checkoutStepOnePage.FillData(staticData.FirstName, staticData.LastName, staticData.PostalCode);

            //Provjeriti jesu li se podaci ispravno učitali
            Assert.That(checkoutStepOnePage.GetFirstName(), Does.Contain(staticData.FirstName));
            Assert.That(checkoutStepOnePage.GetLastName(), Does.Contain(staticData.LastName));
            Assert.That(checkoutStepOnePage.GetPostalCode(), Does.Contain(staticData.PostalCode));

            //Kliknuti continiue i provjeriti je li se učitala stranica
            checkoutStepOnePage.ClickContinueButton();
            Assert.That(driver.Url, Does.Contain(staticData.CheckoutStepTwoUrl));

            //Potvrditi da cijena nije 0
            string priceText = checkoutStepTwoPage.GetTotalPrice();
            Assert.That(priceText, Does.Not.Contain("Total: $0.00"));

            //Naručivanje je gotovo - provjeriti je li se učitala stranica za Checkout complete
            checkoutStepTwoPage.ClickFinishButton();
            Assert.That(driver.Url, Does.Contain(staticData.CheckoutCompleteUrl));

            //Vratiti se na početnu stranicu
            checkoutCompletePage.ClickBackToHomeButton();
            Assert.That(driver.Url, Does.Contain(staticData.InventoryURL));
        }


    }
}
