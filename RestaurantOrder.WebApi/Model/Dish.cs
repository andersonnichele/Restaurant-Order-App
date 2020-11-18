namespace RestaurantOrder.Api.Model
{
    public class Dish
    {
        public DishType DishType { get; set; }

        public string Name { get; set; }

        public TimeOfDay TimeOfDayServed { get; set; }

        public bool AllowMultipleOrders { get; set; }
    }
}