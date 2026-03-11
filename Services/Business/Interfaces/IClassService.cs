using StageWise.Dtos.Class.Request;
using StageWise.Dtos.Class.Response;

namespace StageWise.Services.Business.Interfaces
{
    public interface IClassService
    {
        Task<CreateClassResponse> CreateClassAsync(CreateClassRequest request);
        Task<GetClassResponse> GetClassAsync(int Id);
        Task<List<GetClassResponse>> GetClassesAsync();
    }
}