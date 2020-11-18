using RestaurantOrder.Api.Model;
using RestaurantOrder.Api.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantOrder.Api.Repository
{
    public class DishRepository : IDishRepository
    {
        private List<Dish> DishesList { get; set; }

        public DishRepository()
        {
            PopulateDishes();
        }

        public List<string> GetAllAvailableTimeOfDay()
        {
            return DishesList.Select(x => x.TimeOfDayServed.Name).Distinct().ToList();
        }

        public Dish GetDishNameBydishTypeIdAndTimeOfDay(int dishTypeId, string timeOfDay)
        {
            return DishesList
                .Where(dish =>
                    dish.DishType.Id == dishTypeId &&
                    dish.TimeOfDayServed.Name.Equals(timeOfDay))
                .FirstOrDefault();
        }

        public List<Dish> GetDishesBySishTypeIdListAndTimeOfDay(List<int> dishTypeIdList, string timeOfDay)
        {
            return DishesList
                .Where(dish =>
                    dishTypeIdList.Any(dishType => dishType == dish.DishType.Id) &&
                    dish.TimeOfDayServed.Name.Equals(timeOfDay)).ToList();
        }

        private void PopulateDishes()
        {
            DishesList = new List<Dish>();

            var morningTime = new TimeOfDay { Name = "morning" };
            var nightTime = new TimeOfDay { Name = "night" };

            var entreeDishType = new DishType { Id = 1, Name = "entrée" };

            DishesList.Add(new Dish { DishType = entreeDishType, Name = "eggs", TimeOfDayServed = morningTime, AllowMultipleOrders = false });
            DishesList.Add(new Dish { DishType = entreeDishType, Name = "steak", TimeOfDayServed = nightTime, AllowMultipleOrders = false });

            var sideDishType = new DishType { Id = 2, Name = "side" };

            DishesList.Add(new Dish { DishType = sideDishType, Name = "toast", TimeOfDayServed = morningTime, AllowMultipleOrders = false });
            DishesList.Add(new Dish { DishType = sideDishType, Name = "potato", TimeOfDayServed = nightTime, AllowMultipleOrders = true });

            var drinkDishType = new DishType { Id = 3, Name = "drink" };

            DishesList.Add(new Dish { DishType = drinkDishType, Name = "coffee", TimeOfDayServed = morningTime, AllowMultipleOrders = true });
            DishesList.Add(new Dish { DishType = drinkDishType, Name = "wine", TimeOfDayServed = nightTime, AllowMultipleOrders = false });

            var dessertDishType = new DishType { Id = 4, Name = "dessert" };

            DishesList.Add(new Dish { DishType = dessertDishType, Name = "cake", TimeOfDayServed = nightTime, AllowMultipleOrders = false });
        }
    }
}