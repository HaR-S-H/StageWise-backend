using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageWise.Dtos.Project.Request;
using StageWise.Dtos.Project.Response;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Controllers
{   [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<CreateProjectResponse>> CreateProject(CreateProjectRequest request)
        {
            var response = await _projectService.CreateProjectAsync(request);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        [Authorize(Roles = "Admin,Teacher,Student,Hod")]
        public async Task<ActionResult<GetProjectResponse>> GetProject(int Id)
        {
            var response = await _projectService.GetProjectAsync(Id);
            return Ok(response);
        }
        [HttpGet("All")]
        [Authorize(Roles = "Admin,Teacher,Student,Hod")]
        public async Task<ActionResult<List<GetProjectResponse>>> GetProjects()
        {
            var response = await _projectService.GetProjectsAsync();
            return Ok(response);
        }
    }
}