using AutoMapper;
using StageWise.Dtos.Project.Request;
using StageWise.Dtos.Project.Response;
using StageWise.Helpers.Enums;
using StageWise.Helpers.Exceptions;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _DepartmentRepository;
        private readonly ICourseRepository _courseRepository;
        public ProjectService(IProjectRepository projectRepository,IMapper mapper,ICurrentUserService currentUser,IClassRepository classRepository,IDepartmentRepository departmentRepository,ICourseRepository courseRepository,IStudentRepository studentRepository)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _currentUser = currentUser;
            _classRepository = classRepository;
            _DepartmentRepository = departmentRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
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

        public async  Task<List<GetProjectResponse>> GetProjectsAsync()
        {
            if(_currentUser.Role == UserRole.Admin.ToString())
            {
                var adminProjects = await _projectRepository.GetAllAsync();
                return _mapper.Map<List<GetProjectResponse>>(adminProjects);
            }
            else if(_currentUser.Role == UserRole.Teacher.ToString())
            {
                var classes = await _classRepository.GetClassesByTeacherIdAsync(_currentUser.UserId);
                var classIds = classes.Select(c => c.Id).ToList();
                var teacherProjects = await _projectRepository.GetProjectsByClassIdsAsync(classIds);
                return _mapper.Map<List<GetProjectResponse>>(teacherProjects);
            }
            else if(_currentUser.Role == UserRole.Student.ToString())
            {   var student=await _studentRepository.GetByIdAsync(_currentUser.UserId);
                if(student == null) throw new AppException("Student not found", 404);
                var Studentprojects = await _projectRepository.GetProjectsByClassIdsAsync([student.ClassId]);
                return _mapper.Map<List<GetProjectResponse>>(Studentprojects);
            }
            else if(_currentUser.Role == UserRole.Hod.ToString())
            {
                var department = await _DepartmentRepository.GetByHodIdAsync(_currentUser.UserId);
                if (department == null) throw new AppException("Department not found", 404);
                var courses=await _courseRepository.GetCoursesByDepartmentIdAsync(department.Id);
                if (courses == null) throw new AppException("Courses not found", 404);
                var courseIds = courses.Select(c => c.Id).ToList();
                var classes = await _classRepository.GetClassesByCourseIdsAsync(courseIds);
                var classIds = classes.Select(c => c.Id).ToList();
                var hodProjects = await _projectRepository.GetProjectsByClassIdsAsync(classIds);
                return _mapper.Map<List<GetProjectResponse>>(hodProjects);
            }
            else
            {
                throw new AppException("Unauthorized", 401);
            }
        
        }
    }
}