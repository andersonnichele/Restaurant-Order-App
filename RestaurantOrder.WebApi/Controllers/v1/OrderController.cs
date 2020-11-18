using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Api.Service.Interfaces;

namespace RestaurantOrder.Api.Controllers.v1
{
    public class OrderController : Controller
    {
        private readonly IDishService _dishService;

        public OrderController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet("api/v1/order/{orderInput}")]
        public IActionResult GetOrder([FromRoute] string orderInput)
        {
            string result = _dishService.GetDishesListByOrderInput(orderInput);

            return Ok(result);
        }
    }
}