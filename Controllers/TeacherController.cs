using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageWise.Dtos.Teacher.Request;
using StageWise.Dtos.Teacher.Response;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreateTeacherResponse>> CreateTeacher(CreateTeacherRequest request)
        {
            var response = await _teacherService.CreateTeacherAsync(request);
            return Ok(response);
        }
        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public async Task<ActionResult<GetTeacherResponse>> GetTeacher()
        {
            var response = await _teacherService.GetTeacherAsync();
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("All")]
        public async Task<ActionResult<List<GetTeacherResponse>>> GetTeachers()
        {
            var response = await _teacherService.GetTeachersAsync();
            return Ok(response);
        }
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPatch]
        public async Task<ActionResult<UpdateTeacherResponse>> UpdateTeacher([FromForm] UpdateTeacherRequest request)
        {
            var response = await _teacherService.UpdateTeacherAsync(request);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<ActionResult<DeleteTeacherResponse>> DeleteTeacher(DeleteTeacherRequest request)
        {
            var response = await _teacherService.DeleteTeacherAsync(request);
            return Ok(response);
        }
    }
}