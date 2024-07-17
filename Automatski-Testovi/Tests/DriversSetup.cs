﻿using Automatski_Testovi.Pages;
using Automatski_Testovi.Static_elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Automatski_Testovi.Tests
{
    public class DriversSetup
    {
        public IWebDriver driver;
        public LoginPage? loginPage;
        public InventoryPage? inventoryPage;
        public CartPage? cartPage;
        public CheckoutStepOnePage checkoutStepOnePage;
        public CheckoutStepTwoPage checkoutStepTwoPage;
        public CheckoutCompletePage checkoutCompletePage;
        public StaticData? staticData;

        [OneTimeSetUp]
        public void Setup() 
        {
            EdgeDriverSetUp();

            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
            cartPage = new CartPage(driver);
            checkoutStepOnePage = new CheckoutStepOnePage(driver);
            checkoutStepTwoPage = new CheckoutStepTwoPage(driver);
            checkoutCompletePage = new CheckoutCompletePage(driver);
            staticData = new StaticData();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver?.Dispose();
        }

        private void ChromeDriverSetUp()
        {
            var chromedirectory = Directory.GetCurrentDirectory();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(chromedirectory, options);
        }


        private void EdgeDriverSetUp()
        {
            var options = new EdgeOptions();
            options.AddArgument("--start-maximized");
            driver = new EdgeDriver(options);
        }
    }
}
