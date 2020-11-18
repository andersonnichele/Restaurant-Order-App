using Microsoft.AspNetCore.Mvc.Testing;
using RestaurantOrder.Api;
using System.Net.Http;

namespace RestaurantOrder.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();

            TestClient = appFactory.CreateClient();
        }
    }
}