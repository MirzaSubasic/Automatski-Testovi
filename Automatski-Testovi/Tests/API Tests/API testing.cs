using Automatski_Testovi.Tests.API_Tests.Base_Class;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Automatski_Testovi.Tests.API_Tests
{
    [Parallelizable(ParallelScope.All)]
    public class API_testing : APIBaseClass
    {

        [Test]
        public async Task GetPostsReturnsStatusCodeOk()
        {
            try
            {
                StartTest("GetActivitiesReturnsOkStatusCode");

                HttpResponseMessage response = await client.GetAsync(baseUrl + "posts");

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                LogPassingTest("GetPostsReturnsStatusCodeOk");
            }
            catch (Exception ex)
            {
                LogFailingTest(ex);
            }
        }

        [Test]
        public async Task GetPostsReturnsNonEmptyBody()
        {
            try
            {
                StartTest("GetPostsReturnsNonEmptyBody");

                HttpResponseMessage response = await client.GetAsync(baseUrl + "posts");

                string responseBody = await response.Content.ReadAsStringAsync();
                JArray posts = JArray.Parse(responseBody);
                JObject postWithId1 = posts.FirstOrDefault(post => (int)post["id"] == 1) as JObject;

                Assert.That(postWithId1, Is.Not.Null);
                LogPassingTest("GetPostsReturnsNonEmptyBody");
            }
            catch (Exception ex)
            {
                LogFailingTest(ex);
            }
        }

        [Test]
        public async Task NewPostCanBeCreated()
        {
            try
            {
                StartTest("NewPostCanBeCreated");

                HttpResponseMessage response = await client.PostAsync(baseUrl + "posts/1", PostContent());

                Assert.That(response.StatusCode, Is.EqualTo((HttpStatusCode)HttpStatusCode.OK));
                LogPassingTest("NewPostCanBeCreated");
            }
            catch (Exception ex)
            {
                LogFailingTest(ex);
            }
        }

    }
}
