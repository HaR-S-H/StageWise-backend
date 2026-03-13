// using Microsoft.AspNetCore.Mvc;

// namespace StageWise.Controllers
// {
//     public class ProjectController : ControllerBase
//     {
//         private readonly IProjectService _projectService;
//         public ProjectController(IProjectService projectService)
//         {
//             _projectService = projectService;
//         }
//         public async Task<ActionResult<CreateProjectResponse>> CreateProject(CreateProjectRequest request)
//         {
//             var response = await _projectService.CreateProjectAsync(request);
//             return Ok(response);
//         }
//     }
// }