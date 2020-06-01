using System.Net.Http;
using App.Models;
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
            u = new User { Username = "Iury", Password = "123Testing" };
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
        public async Task Return_message_error_if_username_field_is_empty ()
        {
            u.Username = "";
            string user = JsonSerializer.Serialize(u);
            content = new StringContent(user, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5000/users", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
            Assert.True(responseContent.Contains("Your username cannot be empty."));
        }

        [Test]
        public async Task Return_message_error_if_password_field_is_empty ()
        {
            u.Password = "";
            string user = JsonSerializer.Serialize(u);
            content = new StringContent(user, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5000/users", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.True(responseContent.Contains("Your password cannot be empty."));
        }

        [Test]
        public async Task Return_message_error_if_password_field_is_minor_as_6_characters ()
        {
            u.Password = "casca";
            string user = JsonSerializer.Serialize(u);
            content = new StringContent(user, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5000/users", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.True(responseContent.Contains("Your password must be longer than 6 characters."));
        }

        [Test]
        public async Task check_if_returned_user_is_the_same_sended ()
        {
            //Enviando Usuario para API
            await client.PostAsync("http://localhost:5000/users", content);

            var response = await client.GetAsync("http://localhost:5000/users/1");

            string userTested = JsonSerializer.Serialize(new User { Id = 1, Username = "Iury", Password = "" }).ToLower();

            string userReturned = (await response.Content.ReadAsStringAsync()).ToLower();
            Assert.AreEqual(userTested, userReturned);
        }


    }

}