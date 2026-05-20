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

    }
}
