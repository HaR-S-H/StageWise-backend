using AutoMapper;
using StageWise.Dtos.Course.Request;
using StageWise.Dtos.Course.Response;
using StageWise.Helpers.Exceptions;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository,IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<CreateCourseResponse> CreateCourseAsync(CreateCourseRequest request)
        {
            var existingCourse=await _courseRepository.GetByNameAsync(request.Name);
            if (existingCourse != null) throw new AppException("Course already exists", 409);
            var course=new Course
            {
                Name=request.Name,
                DepartmentId=request.DepartmentId
            };
            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveAsync();
            return new CreateCourseResponse
            {
                Success = true,
                Message = "Course created successfully",
            };
        }

        public async Task<GetCourseResponse> GetCourseAsync(int Id)
        {
            var course = await _courseRepository.GetByIdAsync(Id);
            if (course == null) throw new AppException("Course not found", 404);
            return _mapper.Map<GetCourseResponse>(course);
            
        }
    }
}