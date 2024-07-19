using Automatski_Testovi.Pages;
using Automatski_Testovi.Static_elements;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using NUnit.Framework;
using System.IO;

namespace Automatski_Testovi.Tests
{
    public class BaseClass
    {
        public IWebDriver driver;

        public ExtentReports extent { get; set; }
        public ExtentV3HtmlReporter reporter { get; set; }
        public ExtentTest test { get; set; }

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
            ExtentReportsSetUp();

            ChromeDriverSetUp();

            InitializeClasses();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ExtentReportsTearDown();

            driver?.Dispose();
        }

        private void ChromeDriverSetUp()
        {
            string chromedirectory = Directory.GetCurrentDirectory();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(chromedirectory, options);
        }

        private void EdgeDriverSetUp()
        {
            EdgeOptions options = new EdgeOptions();
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
            string filePath = $"C:\\Users\\{Environment.UserName}\\Downloads\\ExtentReport.html";

            reporter = new ExtentV3HtmlReporter(filePath);
            extent = new ExtentReports();

            reporter.Config.DocumentTitle = "Automation Testing Report";
            reporter.Config.ReportName = "Automation Testing Task";

            extent.AttachReporter(reporter);
        }

        private void ExtentReportsTearDown()
        {
            extent.Flush();
        }
    }
}
