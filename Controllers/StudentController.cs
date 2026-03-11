using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageWise.Dtos.Student.Request;
using StageWise.Dtos.Student.Response;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Controllers{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentController:ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreateStudentResponse>> CreateStudent(CreateStudentRequest request)
        {
            var response = await _studentService.CreateStudentAsync(request);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("All")]
        public async Task<ActionResult<List<GetStudentResponse>>> GetStudents()
        {
            var response = await _studentService.GetStudentsAsync();
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetStudentResponse>> GetStudent(int Id)
        {
            var response = await _studentService.GetStudentAsync(Id);
            return Ok(response);
        }
    }
}