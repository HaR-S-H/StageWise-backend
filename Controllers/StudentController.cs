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
    }
}