using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantOrder.IntegrationTests
{
    public class OrderControllerTests : IntegrationTest
    {
        [Theory]
        [InlineData("morning, 1, 2, 3", "eggs, toast, coffee")]
        [InlineData("night, 1, 2, 3, 4", "steak, potato, wine, cake")]
        public async Task GetOrder_InNumericalOrder(string inputOrder, string outputOrder)
        {
            var response = await TestClient.GetAsync($"api/v1/order/{inputOrder}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ReadAsStringAsync().Result.ToString().Should().Be(outputOrder);
        }

        [Theory]
        [InlineData("MORNING, 1, 2, 3", "eggs, toast, coffee")]
        [InlineData("NIGHT, 1, 2, 3, 4", "steak, potato, wine, cake")]
        [InlineData("mOrNiNg, 1, 2, 3", "eggs, toast, coffee")]
        [InlineData("NiGhT, 1, 2, 3, 4", "steak, potato, wine, cake")]
        public async Task GetOrder_WithNoLowerCase_InTimeDay(string inputOrder, string outputOrder)
        {
            var response = await TestClient.GetAsync($"api/v1/order/{inputOrder}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ReadAsStringAsync().Result.ToString().Should().Be(outputOrder);
        }

        [Theory]
        [InlineData("morning, 2, 1, 3", "eggs, toast, coffee")]
        [InlineData("night, 4, 3, 1, 2", "steak, potato, wine, cake")]
        public async Task GetOrder_NotInNumericalOrder(string inputOrder, string outputOrder)
        {
            var response = await TestClient.GetAsync($"api/v1/order/{inputOrder}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ReadAsStringAsync().Result.ToString().Should().Be(outputOrder);
        }

        [Theory]
        [InlineData("morning, 1, 2, 3, 4", "eggs, toast, coffee, error")]
        [InlineData("night, 1, 2, 3, 5", "steak, potato, wine, error")]
        public async Task GetOrder_WithInvalidDishType(string inputOrder, string outputOrder)
        {
            var response = await TestClient.GetAsync($"api/v1/order/{inputOrder}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ReadAsStringAsync().Result.ToString().Should().Be(outputOrder);
        }

        [Theory]
        [InlineData("morning, 1, 2, 3, 3, 3", "eggs, toast, coffee(x3)")]
        [InlineData("night, 1, 2, 2, 4", "steak, potato(x2), cake")]
        public async Task GetOrder_WithMultipleAvailableOption(string inputOrder, string outputOrder)
        {
            var response = await TestClient.GetAsync($"api/v1/order/{inputOrder}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ReadAsStringAsync().Result.ToString().Should().Be(outputOrder);
        }
    }
}