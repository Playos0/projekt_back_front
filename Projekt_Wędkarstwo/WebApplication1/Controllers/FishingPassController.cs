using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/passes")]
    public class FishingPassController : ControllerBase
    {
        private readonly IFishingPassService _fishingPassService;

        public FishingPassController(IFishingPassService fishingPassService)
        {
            _fishingPassService = fishingPassService;
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyPass([FromBody] BuyFishingPassDto dto)
        {
            await _fishingPassService.BuyPassAsync(dto, User);

            return Ok();
        }

        [HttpGet("MyPasses")]
        [Authorize]
        public async Task<IActionResult> MyPasses()
        {
            var result = await _fishingPassService.GetMyPassesAsync(User);

            return Ok(result);
        }


    }
}
