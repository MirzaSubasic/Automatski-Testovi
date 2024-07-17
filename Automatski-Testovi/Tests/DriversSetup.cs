using Automatski_Testovi.Pages;
using Automatski_Testovi.Static_elements;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace Automatski_Testovi.Tests
{
    public class DriversSetup
    {
        public IWebDriver driver;

        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        public ExtentTest test;

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
            ChromeDriverSetUp();

            ExtentReportsSetUp();

            InitializeClasses();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver?.Dispose();
            ExtentReportsTearDown();
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

        private void InitializeClasses()
        {
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
            cartPage = new CartPage(driver);
            checkoutStepOnePage = new CheckoutStepOnePage(driver);
            checkoutStepTwoPage = new CheckoutStepTwoPage(driver);
            checkoutCompletePage = new CheckoutCompletePage(driver);
            staticData = new StaticData();
        }

        private void ExtentReportsSetUp()
        {
            string downloadsFolder = "C:\\Users\\USER_NAME\\Downloads\\".Replace("USER_NAME", Environment.UserName);

            var htmlReporter = new ExtentV3HtmlReporter(downloadsFolder + "ExentReport.html");

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        private void ExtentReportsTearDown()
        {
            extent.Flush();
        }

    }
}
