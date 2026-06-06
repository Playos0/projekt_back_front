using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/fishingspots")]
    public class FishingSpotController : ControllerBase
    {
        private readonly IFishingSpotService _fishingSpotService;

        public FishingSpotController(IFishingSpotService fishingSpotService)
        {
            _fishingSpotService = fishingSpotService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _fishingSpotService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _fishingSpotService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound($"No Fishing Spot with id: {id}");
            }
            return Ok(result);  
        }
    }
}
