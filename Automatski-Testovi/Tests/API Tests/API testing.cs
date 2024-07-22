﻿using Automatski_Testovi.Tests.API_Tests.Base_Class;
using AventStack.ExtentReports;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Automatski_Testovi.Tests.API_Tests
{
    //[Parallelizable(ParallelScope.All)]
    //[TestFixture]
    public class API_testing : APIBaseClass
    {

        [Test]
        public async Task GetPostsReturnsStatusCodeOkTest()
        {
            try
            {
                StartTest("GetPostsReturnsStatusCodeOkTest");

                HttpResponseMessage response = await client.GetAsync(baseUrl + "posts");

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
                StartTest("GetPostsReturnsNonEmptyBodyTest");

                HttpResponseMessage response = await client.GetAsync(baseUrl + "posts");

                string responseBody = await response.Content.ReadAsStringAsync();
                JArray posts = JArray.Parse(responseBody);
                JObject postWithId1 = posts.FirstOrDefault(post => (int)post["id"] == 1) as JObject;

                Assert.That(postWithId1, Is.Not.Null);
                test.Log(Status.Pass, "GetPostsReturnsNonEmptyBodyTest completed successfully");
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
                StartTest("PostReturnsStatusCodeOkTest");

                HttpResponseMessage response = await client.PostAsync(baseUrl + "posts", PostContent());

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
                StartTest("DeleteReturnsStatusCodeOkTest");

                HttpResponseMessage response = await client.DeleteAsync(baseUrl + "posts/1");
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
