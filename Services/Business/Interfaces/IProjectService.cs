using StageWise.Dtos.Project.Request;
using StageWise.Dtos.Project.Response;

namespace StageWise.Services.Business.Interfaces
{
    public interface IProjectService
    {
        Task<CreateProjectResponse> CreateProjectAsync(CreateProjectRequest request);
        Task<GetProjectResponse> GetProjectAsync(int Id);
        Task<List<GetProjectResponse>> GetProjectsAsync();
        Task<DeleteProjectResponse> DeleteProjectAsync(int Id);
    }
}