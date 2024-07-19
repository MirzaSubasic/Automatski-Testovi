using Automatski_Testovi.Tests.API_Tests.Base_Class;
using AventStack.ExtentReports;
using System.Net;

namespace Automatski_Testovi.Tests.API_Tests
{
    [Parallelizable(ParallelScope.All)]
    public class API_testing : APIBaseClass
    {

        [Test]
        public async Task GetActivitiesReturnsOkStatusCode()
        {
            try
            {
                //Upisati u report da je krenuo test
                test = extent.CreateTest("GetActivitiesReturnsOkStatusCode").Info("GetActivitiesReturnsOkStatusCode Test Started");

                var response = await client.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Activities");

                // Assert
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                test.Log(Status.Pass, "GetActivitiesReturnsOkStatusCode completed successfully");
            }
            catch (Exception ex)
            {
                // Ukoliko test padne uraditi log
                test.Log(Status.Fail, ex.ToString());
                throw;
            }
        }

    }
}
