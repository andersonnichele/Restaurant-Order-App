namespace RestaurantOrder.Api.Service.Interfaces
{
    public interface IDishService
    {
        string GetDishesListByOrderInput(string orderInput);
    }
}