using Microsoft.AspNetCore.Mvc;
using LicenseSalesApp.DTOs;
using LicenseSalesApp.Services;
using System.Threading.Tasks;

namespace LicenseSalesApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(OrderDto orderDto)
        {
            var response = await _orderService.PlaceOrderAsync(orderDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            var response = await _orderService.GetUserOrdersAsync(userId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }
    }
}
