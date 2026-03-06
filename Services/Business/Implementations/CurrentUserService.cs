using System.Security.Claims;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public int UserId =>
            int.Parse(_contextAccessor.HttpContext!.User
                .FindFirst(ClaimTypes.NameIdentifier)!.Value);

        public string Email =>
            _contextAccessor.HttpContext!.User
                .FindFirst(ClaimTypes.Email)!.Value;

        public string Role =>
            _contextAccessor.HttpContext!.User
                .FindFirst(ClaimTypes.Role)!.Value;
    }
}