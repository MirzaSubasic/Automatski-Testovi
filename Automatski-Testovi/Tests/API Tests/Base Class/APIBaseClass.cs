using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.Text;
using Newtonsoft.Json;


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

        public string baseUrl { get; set; } = "https://jsonplaceholder.typicode.com/";

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

        protected void StartTest(string testName)
        {
            test = extent.CreateTest(testName).Info(testName + " Test Started");
        }

        protected void LogPassingTest(string testName)
        {
            test.Log(Status.Pass, testName + "completed successfully");
        }

        protected void LogFailingTest(Exception ex)
        {
            test.Log(Status.Fail, ex.ToString());
        }

        protected HttpContent PostContent()
        {
            var contentObject = new
            {
                title = "foo",
                body = "bar",
                userId = 1
            };

            string jsonContent = JsonConvert.SerializeObject(contentObject);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            return content;
        }
    }
}
