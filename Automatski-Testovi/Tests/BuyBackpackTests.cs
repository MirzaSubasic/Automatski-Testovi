
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
            var items = inventoryPage.GetElements();
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

            cartPage.GoToCheckoutButtonClick();
            Assert.That(driver.Url, Does.Contain(staticData.CheckoutUrl));

            checkoutStepOnePage.FillData(staticData.FirstName, staticData.LastName, staticData.PostalCode);

            Assert.That(staticData.FirstName, Does.Contain(checkoutStepOnePage.GetFirstName()));
            Assert.That(staticData.LastName, Does.Contain(checkoutStepOnePage.GetLastName()));
            Assert.That(staticData.PostalCode, Does.Contain(checkoutStepOnePage.GetPostalCode()));

            checkoutStepOnePage.ClickContiniueButton();
            Assert.That(driver.Url, Does.Contain(staticData.CheckoutStepTwoUrl));


            var priceText = checkoutStepTwoPage.GetTotalPrice();
            Assert.That(priceText, Does.Not.Contain("Total: $0.00"));


            checkoutStepTwoPage.ClickFinishButton();
            Assert.That(driver.Url, Does.Contain(staticData.CheckoutCompleteUrl));


            checkoutCompletePage.ClickBackToHomeButton();
            Assert.That(driver.Url, Does.Contain(staticData.InventoryURL));
        }


    }
}
