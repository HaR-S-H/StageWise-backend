using StageWise.Dtos.Stage.Request;
using StageWise.Dtos.Stage.Response;

namespace StageWise.Services.Business.Interfaces
{
    public interface IStageService
    {
        Task<CreateStageResponse> CreateStageAsync(CreateStageRequest request);
        Task<DeleteStageResponse> DeleteStageAsync(int id);
    }
}