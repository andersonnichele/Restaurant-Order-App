using RestaurantOrder.Api.Repository.Interfaces;
using RestaurantOrder.Api.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantOrder.Api.Service
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _orderRepository;

        public DishService(IDishRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public string GetDishesListByOrderInput(string orderInput)
        {
            orderInput = orderInput.ToLower();

            if (HasInputOrderErros(orderInput))
            {
                return "error";
            }

            List<string> foodList = new List<string>();

            var orderInputAsList = orderInput.Split(',');

            var timeOfDay = orderInputAsList[0];

            var lastIndexWithNoError = GetLastIndexWithNoErroFromInputOrder(orderInputAsList, timeOfDay);

            var orderInputAsListWithNoError = orderInputAsList.Skip(1).Take(lastIndexWithNoError).Select(int.Parse).ToList();

            var dishList = _orderRepository.GetDishesBySishTypeIdListAndTimeOfDay(orderInputAsListWithNoError, timeOfDay)
                                            .OrderBy(dish => dish.DishType.Id).ToList();

            foreach (var dish in dishList.OrderBy(dish => dish.DishType.Id))
            {
                var countOrderedDishes = orderInputAsListWithNoError.Count(x => x == dish.DishType.Id);

                if (dish.AllowMultipleOrders && countOrderedDishes > 1)
                {
                    foodList.Add($"{dish.Name}(x{countOrderedDishes})");
                }
                else
                {
                    foodList.Add(dish.Name);
                }
            }

            if (orderInputAsListWithNoError.Count() < orderInputAsList.Skip(1).Count())
            {
                foodList.Add("error");
            }

            return string.Join(", ", foodList);
        }

        private bool HasInputOrderErros(string orderInput)
        {
            if (string.IsNullOrEmpty(orderInput))
            {
                return true;
            }

            var entriesList = orderInput.Split(',');

            if (entriesList.Count() <= 1)
            {
                return true;
            }

            return !_orderRepository.GetAllAvailableTimeOfDay().Contains(entriesList[0]);
        }

        private int GetLastIndexWithNoErroFromInputOrder(string[] inputOrderList, string timeOfDay)
        {
            int lastIndexWithNoErro = 0;

            for (int i = 1; i < inputOrderList.Count(); i++)
            {
                if (IsInputSectionInvalid(inputOrderList[i], inputOrderList, timeOfDay))
                {
                    break;
                }

                lastIndexWithNoErro = i;
            }

            return lastIndexWithNoErro;
        }

        private bool IsInputSectionInvalid(string inputSection, string[] inputOrderList, string timeOfDay)
        {
            if (!Int32.TryParse(inputSection, out int inputNumber))
            {
                return false;
            }

            var dish = _orderRepository.GetDishNameBydishTypeIdAndTimeOfDay(inputNumber, timeOfDay);

            return (dish == null || (inputOrderList.Count(x => x.Equals(inputSection)) > 1 && !dish.AllowMultipleOrders));
        }
    }
}