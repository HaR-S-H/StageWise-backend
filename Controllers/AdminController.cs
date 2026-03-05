using Microsoft.AspNetCore.Mvc;
using StageWise.Dtos.Admin.Request;
using StageWise.Dtos.Admin.Response;
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

}
    
}