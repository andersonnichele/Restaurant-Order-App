using System.Threading.Tasks;

namespace RestaurantOrderApp.Client.Service.Interfaces
{
    public interface IRestaurantOrderService
    {
        Task<string> GetOrder(string inputOrder);
    }
}