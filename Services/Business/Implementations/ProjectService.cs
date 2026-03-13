using StageWise.Dtos.Project.Request;
using StageWise.Dtos.Project.Response;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<CreateProjectResponse> CreateProjectAsync(CreateProjectRequest request)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description,
                ClassId = request.ClassId
            };
            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveAsync();
            return new CreateProjectResponse { Success = true, Message = "Project created successfully" };
        }
    }
}