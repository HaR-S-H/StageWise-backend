using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageWise.Dtos.Course.Request;
using StageWise.Dtos.Course.Response;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CourseController: ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreateCourseResponse>> CreateCourse(CreateCourseRequest request)
        {
            var response = await _courseService.CreateCourseAsync(request);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetCourseResponse>> GetCourse(int Id)
        {
            var response =await _courseService.GetCourseAsync(Id);
            return Ok(response);
        }
    }
}