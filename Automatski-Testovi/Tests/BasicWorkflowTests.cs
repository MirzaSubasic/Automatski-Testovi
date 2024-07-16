

namespace Automatski_Testovi.Tests
{
    [TestFixture]
    public class Tests: DriversSetup
    {

        [Test]
        public void InventoryItemsTest()
        {
            loginPage.LogIn(staticData.StandardUser, staticData.Password);

            var items = inventoryPage.GetElements();

            Assert.That(items.Count, Is.Not.EqualTo(0));

        }

        [Test]
        public void AddToCartTest()
        {
            loginPage.LogIn(staticData.StandardUser, staticData.Password);

            inventoryPage.AddBackpackToCart();

            string buttonText = inventoryPage.VerifyTextForRemoveFromCartButton();

            Assert.That(buttonText, Does.Contain("Remove"));
        }

        [Test]
        public void GoToCartTest() 
        {
            loginPage.LogIn(staticData.StandardUser, staticData.Password);

            inventoryPage.GoToCartBadgeClick();

            Assert.That(driver.Url, Does.Contain(staticData.CartUrl));
        }

        [Test]
        public void ItemExistsInCartTest()
        {
            var removeButtonText = cartPage?.FindRemoveButtonText();

            Assert.That(removeButtonText, Does.Contain("Remove"));
        }

        [Test]
        public void ClickCheckoutButtonAndVerifyUrlTest()
        {
            cartPage.GoToCheckoutButtonClick();

            Assert.That(driver.Url, Does.Contain(staticData.CheckoutUrl));
        }

        [Test]
        public void CorrectInputIsEnteredInCheckoutTest()
        {
            checkoutStepOnePage.FillData(staticData.FirstName, staticData.LastName, staticData.PostalCode);

            Assert.That(staticData.FirstName, Does.Contain(checkoutStepOnePage.GetFirstName())); 
            Assert.That(staticData.LastName, Does.Contain(checkoutStepOnePage.GetLastName()));
            Assert.That(staticData.PostalCode, Does.Contain(checkoutStepOnePage.GetPostalCode()));

        }

        [Test]
        public void FillDataInCheckoutTest()
        {
            checkoutStepOnePage.FillData(staticData.FirstName, staticData.LastName, staticData.PostalCode);
            
            checkoutStepOnePage.ClickContiniueButton();

            Assert.That(driver.Url, Does.Contain(staticData.CheckoutStepTwoUrl));
        }

        [Test]
        public void FinalPriceIsNonZeroTest()
        {
            var priceText = checkoutStepTwoPage.GetTotalPrice();

            Console.WriteLine(driver.Url);

            Assert.That(priceText, Does.Not.Contain("Total: $0.00"));
        }

        [Test]
        public void FinishOrderButtonTest()
        {
            checkoutStepTwoPage.ClickFinishButton();

            Assert.That(driver.Url, Does.Contain(staticData.CheckoutCompleteUrl));

        }

        [Test]
        public void BackToHomeButtonAfterOrderIsCompleteTest()
        {
            checkoutCompletePage.ClickBackToHomeButton();

            Assert.That(driver.Url, Does.Contain(staticData.InventoryURL));
        }

    }
}
