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
    }
}