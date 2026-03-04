using AutoMapper;
using StageWise.Models;
using StageWise.Dtos.Auth.Response;

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

            // You can add more mappings here later
            // CreateMap<Entity, Dto>();
        }
    }
}