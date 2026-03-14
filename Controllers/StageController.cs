using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageWise.Dtos.Stage.Request;
using StageWise.Dtos.Stage.Response;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StageController : ControllerBase
    {
        private readonly IStageService _stageService;
        public StageController(IStageService stageService)
        {
            _stageService = stageService;
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<ActionResult<CreateStageResponse>> CreateStage(CreateStageRequest request)
        {
            var response = await _stageService.CreateStageAsync(request);
            return Ok(response);
        }
    }
}