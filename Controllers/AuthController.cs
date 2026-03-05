using Microsoft.AspNetCore.Mvc;
using StageWise.Dtos.Auth.Request;
using StageWise.Dtos.Auth.Response;
using StageWise.Helpers.Interfaces;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase{
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;
        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;    
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request){
        
            var response =await _authService.LoginAsync(request);
            if (response == null)
            {
                return Unauthorized("Invalid credentials");
            }
            var token = _jwtService.GenerateToken(response.Id, response.Email, response.Role.ToString());
            Response.Cookies.Append("token", token, new CookieOptions
    {
        HttpOnly = true,
        Secure = true,
        SameSite = SameSiteMode.Strict,
        Expires = DateTime.UtcNow.AddHours(1)
    });
          return Ok(response);
            
        }
        
    }
    
}