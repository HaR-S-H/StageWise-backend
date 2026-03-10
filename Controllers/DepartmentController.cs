using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageWise.Dtos.Department.Request;
using StageWise.Dtos.Department.Response;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentController:ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreateDepartmentResponse>> CreateDepartment(CreateDepartmentRequest request)
        {
            var response = await _departmentService.CreateDepartmentAsync(request);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetDepartmentResponse>> GetDepartment(int Id)
        {
            var response = await _departmentService.GetDepartmentAsync(Id);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("All")]
        public async Task<ActionResult<List<GetDepartmentResponse>>> GetDepartments()
        {
            var response = await _departmentService.GetDepartmentsAsync();
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteDepartmentResponse>> DeleteDepartment(int Id)
        {
            var response = await _departmentService.DeleteDepartmentAsync(Id);
            return Ok(response);
        }
    }
}