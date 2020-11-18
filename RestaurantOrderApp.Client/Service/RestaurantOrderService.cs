using RestaurantOrderApp.Client.Service.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestaurantOrderApp.Client.Service
{
    public class RestaurantOrderService : IRestaurantOrderService
    {
        private const string ApiURL = "https://restaurantorderapp.azurewebsites.net";
        private const string GetOrderRoute = "/api/v1/order/{0}";

        private readonly IHttpClientFactory _httpClientFactory;

        public RestaurantOrderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetOrder(string inputOrder)
        {
            try
            {
                var formattedUrl = string.Format(ApiURL + GetOrderRoute, inputOrder);
                var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
                result.EnsureSuccessStatusCode();

                var content = await result.Content.ReadAsStringAsync();
                return await result.Content.ReadAsStringAsync();
            }
            catch
            {
                return "error";
            }
        }
    }
}