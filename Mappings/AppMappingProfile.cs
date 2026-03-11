using AutoMapper;
using StageWise.Models;
using StageWise.Dtos.Auth.Response;
using StageWise.Dtos.Admin.Response;
using StageWise.Dtos.Hod.Request;
using StageWise.Dtos.Hod.Response;
using StageWise.Dtos.Teacher.Response;
using StageWise.Dtos.Teacher.Request;
using StageWise.Dtos.Department.Response;
using StageWise.Dtos.Course.Response;
using StageWise.Dtos.Class.Request;
using StageWise.Dtos.Class.Response;

namespace StageWise.Mappings
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            // Login mapping
            CreateMap<Hod, LoginResponse>();
            CreateMap<Teacher, LoginResponse>();
            CreateMap<Student, LoginResponse>();
            CreateMap<Admin, LoginResponse>();
            CreateMap<Admin, GetAdminResponse>();
            CreateMap<CreateHodRequest, Hod>();
            CreateMap<Hod, CreateHodResponse>();
            CreateMap<Hod, GetHodResponse>();
            CreateMap<CreateTeacherRequest,Teacher>();
            CreateMap<Teacher, CreateTeacherResponse>();
            CreateMap<Teacher, GetTeacherResponse>();
            CreateMap<Department, GetDepartmentResponse>();
            CreateMap<Course, GetCourseResponse>();
            CreateMap<CreateClassRequest, Class>();
            CreateMap<Class, GetClassResponse>();
            
            // You can add more mappings here later
            // CreateMap<Entity, Dto>();
        }
    }
}