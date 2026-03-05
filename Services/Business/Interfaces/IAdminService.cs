using StageWise.Dtos.Admin.Request;
using StageWise.Dtos.Admin.Response;

namespace StageWise.Services.Business.Interfaces
{

    public interface IAdminService
    {

        Task<CreateAdminResponse> CreateAdminAsync(CreateAdminRequest request);


    }
    
}