using Automatski_Testovi.Tests.API_Tests.Base_Class;
using AventStack.ExtentReports;
using Newtonsoft.Json.Linq;
using System.Net;
using RestSharp;

namespace Automatski_Testovi.Tests.API_Tests
{
    [TestFixture]
    public class API_testing : APIBaseClass
    {

        [Test]
        public async Task GetPostsReturnsStatusCodeOkTest()
        {
            try
            {
                test = extent.CreateTest("GetPostsReturnsStatusCodeOkTest").Info("GetPostsReturnsStatusCodeOkTest Test Started");

                RestRequest request = new RestRequest(baseUrl + "posts");
                RestResponse response = await client.GetAsync(request);

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                test.Log(Status.Pass, "GetPostsReturnsStatusCodeOkTest completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.ToString());
                throw;
            }
        }

        [Test]
        public async Task GetPostsReturnsNonEmptyBodyTest()
        {
            try
            {
                test = extent.CreateTest("GetPostsReturnsNonEmptyBodyTest").Info("GetPostsReturnsNonEmptyBodyTest Test Started");

                RestRequest request = new RestRequest(baseUrl + "posts");
                RestResponse response = await client.GetAsync(request);

                JArray jsonResponse = JArray.Parse(response.Content);
                JObject firstElement = (JObject)jsonResponse[0];

                Assert.That(firstElement, Is.Not.Null);
                Assert.That((int)firstElement["id"], Is.EqualTo(1));
                Assert.That((string)firstElement["body"], Is.EqualTo(body));
                Assert.That((string)firstElement["title"], Is.EqualTo(title));
                test.Log(Status.Pass, "GetPostsReturnsNonEmptyBodyTest completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.ToString());
                throw;
            }
        }

        [Test]
        public async Task GetNonExistingPostReturnsEmptyListTest()
        {
            try
            {
                test = extent.CreateTest("GetNonExistingPostReturnsEmptyListTest").Info("GetNonExistingPostReturnsEmptyListTest Test Started");

                RestRequest request = new RestRequest(baseUrl + "posts/101");
                RestResponse response = await client.GetAsync(request);

                Assert.That(response.Content, Is.EqualTo("{}"));
                test.Log(Status.Pass, "GetNonExistingPostReturnsEmptyListTest completed successfully");
            }
            catch(Exception ex)
            {
                test.Log(Status.Fail, ex.ToString());
                throw;
            }
        }

        [Test]
        public async Task NotFoundTest()
        {
            try
            {
                test = extent.CreateTest("NotFoundTest").Info("NotFoundTest Test Started");

                RestRequest request = new RestRequest(baseUrl + "thisPageDoesNotExist");
                RestResponse response = await client.GetAsync(request);

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                test.Log(Status.Pass, "NotFoundTest completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.ToString());
                throw;
            }
        }

        [Test]
        public async Task PostReturnsStatusCodeOkTest()
        {
            try
            {
                test = extent.CreateTest("PostReturnsStatusCodeOkTest").Info("PostReturnsStatusCodeOkTest Test Started");

                RestRequest request = new RestRequest(baseUrl + "posts", Method.Post);
                AddParameters(request);
                RestResponse response = await client.PostAsync(request);

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
                test.Log(Status.Pass, "PostReturnsStatusCodeOkTest completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.ToString());
                throw;
            }
        }

        [Test]
        public async Task DeleteReturnsStatusCodeOkTest()
        {
            try
            {
                test = extent.CreateTest("DeleteReturnsStatusCodeOkTest").Info("DeleteReturnsStatusCodeOkTest Test Started");

                RestRequest request = new RestRequest(baseUrl + "posts/1", Method.Delete);
                RestResponse response = await client.DeleteAsync(request);

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

                test.Log(Status.Pass, "DeleteReturnsStatusCodeOkTest completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.ToString());
                throw;
            }
        }
    }
}
