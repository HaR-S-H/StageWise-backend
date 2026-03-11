using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageWise.Dtos.Class.Request;
using StageWise.Dtos.Class.Response;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreateClassResponse>> CreateClass(CreateClassRequest request)
        {
            var response = await _classService.CreateClassAsync(request);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<GetClassResponse>> GetClass(int Id)
        {
            var response = await _classService.GetClassAsync(Id);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("All")]
        public async Task<ActionResult<List<GetClassResponse>>> GetClasses()
        {
            var response = await _classService.GetClassesAsync();
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteClassResponse>> DeleteClass(int Id)
        {
            var response =await _classService.DeleteClassAsync(Id);
            return Ok(response);
        }
    }
}