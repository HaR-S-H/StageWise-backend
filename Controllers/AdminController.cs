using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageWise.Dtos.Admin.Request;
using StageWise.Dtos.Admin.Response;
using StageWise.Helpers.Enums;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Controllers
{

[ApiController]
[Route("api/v1/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;

    }
        [HttpPost]
        public async Task<ActionResult<CreateAdminResponse>> CreateAdmin(CreateAdminRequest request)
        {
            var response = await _adminService.CreateAdminAsync(request);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<GetAdminResponse>> GetAdmin()
        {
            var response = await _adminService.GetAdminAsync();
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("All")]
        public async Task<ActionResult<List<GetAdminResponse>>> GetAdmins()
        {
            var response=await _adminService.GetAdminsAsync();
            return Ok(response);
        } 

}
    
}