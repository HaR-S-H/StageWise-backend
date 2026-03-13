using AutoMapper;
using StageWise.Dtos.Project.Request;
using StageWise.Dtos.Project.Response;
using StageWise.Helpers.Exceptions;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository,IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;

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

        public async Task<GetProjectResponse> GetProjectAsync(int Id)
        {
            var project = await _projectRepository.GetByIdAsync(Id);
            if (project == null) throw new AppException("Project not found", 404);
            return _mapper.Map<GetProjectResponse>(project);
            
        }
    }
}