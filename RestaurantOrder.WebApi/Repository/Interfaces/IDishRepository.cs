using RestaurantOrder.Api.Model;
using System.Collections.Generic;

namespace RestaurantOrder.Api.Repository.Interfaces
{
    public interface IDishRepository
    {
        List<string> GetAllAvailableTimeOfDay();

        Dish GetDishNameBydishTypeIdAndTimeOfDay(int dishTypeId, string timeOfDay);

        List<Dish> GetDishesBySishTypeIdListAndTimeOfDay(List<int> dishTypeIdList, string timeOfDay);
    }
}