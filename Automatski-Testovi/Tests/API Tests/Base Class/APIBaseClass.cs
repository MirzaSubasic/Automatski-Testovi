using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace Automatski_Testovi.Tests.API_Tests.Base_Class
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class APIBaseClass
    {
        public HttpClient client;

        public ExtentReports extent { get; set; }
        public ExtentV3HtmlReporter reporter { get; set; }
        public ExtentTest test { get; set; }

        [SetUp]
        public void Setup() 
        { 
            ExtentReportsSetUp();
            client = new HttpClient(); 
        }


        [TearDown]
        public void TearDown() 
        { 
            client.Dispose(); 
            ExtentReportsTearDown();
        }

        private void ExtentReportsSetUp()
        {
            string filePath = $"C:\\Users\\{Environment.UserName}\\Downloads\\ExtentReport API.html";

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
