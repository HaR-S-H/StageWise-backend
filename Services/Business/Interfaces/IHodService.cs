using StageWise.Dtos.Hod.Request;
using StageWise.Dtos.Hod.Response;

namespace StageWise.Services.Business.Interfaces
{
    public interface IHodService
    {
        Task<CreateHodResponse> CreateHodAsync(CreateHodRequest request);
        Task<GetHodResponse> GetHodAsync();
        Task<List<GetHodResponse>> GetHodsAsync();
    }
}