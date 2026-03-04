using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        public AuthController(IAuthService authService, IJwtService jwtService,IMapper mapper)
        {
            _authService = authService;    
            _jwtService = jwtService;
            _mapper = mapper;
        }
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request){
        
            var user =await _authService.LoginAsync(request);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }
            var token = _jwtService.GenerateToken(user.Id, user.Email, user.Role.ToString());
            Response.Cookies.Append("token", token, new CookieOptions
    {
        HttpOnly = true,
        Secure = true,
        SameSite = SameSiteMode.Strict,
        Expires = DateTime.UtcNow.AddHours(1)
    });
            var response = _mapper.Map<LoginResponse>(user);
          return Ok(response);
            
        }
        
    }
    
}