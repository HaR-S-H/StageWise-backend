using StageWise.Dtos.Student.Request;
using StageWise.Dtos.Student.Response;

namespace StageWise.Services.Business.Interfaces
{
    public interface IStudentService
    {
        Task<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request);
        Task<GetStudentResponse> GetStudentAsync(int Id);
        Task<List<GetStudentResponse>> GetStudentsAsync();
    }
}