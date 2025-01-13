using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using RestSharp;

namespace Automatski_Testovi.Tests.API_Tests.Base_Class
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class APIBaseClass
    {
        //public HttpClient client;

        public RestClient client;

        public ExtentReports extent { get; set; }
        public ExtentReports extentReports { get; set; }
        public ExtentTest test { get; set; }

        public string baseUrl { get; set; } = "https://jsonplaceholder.typicode.com/";
        public string title { get; set; } = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit";
        public string body { get; set; } = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto";

        [OneTimeSetUp]
        public void Setup() 
        { 
            ExtentReportsSetUp();
            client = new RestClient(); 
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            ExtentReportsTearDown();
            client.Dispose(); 
        }

        private void ExtentReportsSetUp()
        {
            string filePath = $"C:\\Users\\{Environment.UserName}\\Downloads\\ExtentReport API.html";

            ExtentSparkReporter reporter = new ExtentSparkReporter(filePath);
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

        protected void AddParameters(RestRequest request)
        {
            request.AddParameter("title", "Title");
            request.AddParameter("body", "Body 123");
            request.AddParameter("userId", 1);
        }
    }
}
