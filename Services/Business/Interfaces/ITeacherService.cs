using StageWise.Dtos.Teacher.Request;
using StageWise.Dtos.Teacher.Response;

namespace StageWise.Services.Business.Interfaces
{
    public interface ITeacherService
    {
        Task<CreateTeacherResponse> CreateTeacherAsync(CreateTeacherRequest request);
        Task<GetTeacherResponse> GetTeacherAsync();
        Task<List<GetTeacherResponse>> GetTeachersAsync();
        Task<UpdateTeacherResponse> UpdateTeacherAsync(UpdateTeacherRequest request);
        Task<DeleteTeacherResponse> DeleteTeacherAsync(DeleteTeacherRequest request);
    }
}