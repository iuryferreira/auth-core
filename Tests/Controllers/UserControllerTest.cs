using System.Net.Http;
using App;
using App.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System;
using Tests.Service;

namespace Tests.Controllers
{

    [TestFixture]
    public class UserControllerTests
    {

        private HttpClient client;
        private User u;
        private StringContent content;

        [SetUp]
        public void SetUp ()
        {
            client = new ServerService().GetClient();
            u = new User { Username = "Iury", Password = "123" };
            string user = JsonSerializer.Serialize(u);
            content = new StringContent(user, Encoding.UTF8, "application/json");

        }

        [Test]
        public async Task Return_201_if_user_is_created ()
        {
            var response = await client.PostAsync("http://localhost:5000/users", content);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public async Task Return_200_if_user_is_returned ()
        {
            //Enviando Usuario para API
            await client.PostAsync("http://localhost:5000/users", content);

            var response = await client.GetAsync("http://localhost:5000/users/1");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task check_if_returned_user_is_the_same_sended ()
        {
            //Enviando Usuario para API
            await client.PostAsync("http://localhost:5000/users", content);

            var response = await client.GetAsync("http://localhost:5000/users/1");

            string userTested = JsonSerializer.Serialize(new User { Id = 1, Username = "Iury", Password = "", LastAccess = null }).ToLower();

            string userReturned = (await response.Content.ReadAsStringAsync()).ToLower();
            Assert.AreEqual(userTested, userReturned);
        }


    }

}