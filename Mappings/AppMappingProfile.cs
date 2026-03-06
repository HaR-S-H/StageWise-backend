using AutoMapper;
using StageWise.Models;
using StageWise.Dtos.Auth.Response;
using StageWise.Dtos.Admin.Response;
using StageWise.Dtos.Hod.Request;
using StageWise.Dtos.Hod.Response;

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
            
            // You can add more mappings here later
            // CreateMap<Entity, Dto>();
        }
    }
}