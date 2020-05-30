using NUnit.Framework;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Hosting;
using App;

namespace Tests.Service
{

    public interface IServerService
    {
        public HttpClient GetClient ();

    }


    public class ServerService : IServerService
    {

        private IWebHostBuilder webHostBuilder;
        private TestServer server;
        private HttpClient client;

        public ServerService ()
        {
            this.Load();
        }

        private void Load ()
        {
            webHostBuilder = new WebHostBuilder()
            .UseEnvironment("Testing")
            .UseStartup<Startup>();
            server = new TestServer(webHostBuilder);
            client = server.CreateClient();
        }

        public HttpClient GetClient ()
        {
            return this.client;
        }
    }
}