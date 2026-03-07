using StageWise.Dtos.Auth.Response;
using StageWise.Dtos.Auth.Request;
namespace StageWise.Services.Business.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request);
        Task<ForgetPasswordResponse> ForgetPasswordAsync(ForgetPasswordRequest request);
    }
}