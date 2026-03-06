using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageWise.Dtos.Hod.Request;
using StageWise.Dtos.Hod.Response;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HodController:ControllerBase
    {
        private readonly IHodService _hodService;
        public HodController(IHodService hodService)
        {
            _hodService = hodService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreateHodResponse>> CreateHod(CreateHodRequest request)
        {
            var response = await _hodService.CreateHodAsync(request);
            return Ok(response);
        }
        // [Authorize(Roles ="Admin")]
        // [Authorize(Roles = "Hod")]
        [HttpGet]
        public async Task<ActionResult<GetHodResponse>> GetHod()
        {
            var response = await _hodService.GetHodAsync();
            return Ok(response);
        }
    }
}