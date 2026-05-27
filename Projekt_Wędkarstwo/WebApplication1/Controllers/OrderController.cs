using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto, [FromServices] IOrderService orderService)
        {
            try
            {
                var result = await orderService.CreateOrderAsync(dto, User);
                return Ok(result);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("my")]
        [Authorize]
        public async Task<IActionResult> GetMyOrders([FromServices] IOrderService orderService)
        {
            var orders = await orderService.GetMyOrdersAsync(User);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetOrderByID(int id, [FromServices] IOrderService orderService)
        {
            var order = await orderService.GetOrderByIdAsync(id, User);

            if(order == null)
            {
                return NotFound("Order not found or you do not have access to it.");
            }

            return Ok(order);
        }
    }
}
