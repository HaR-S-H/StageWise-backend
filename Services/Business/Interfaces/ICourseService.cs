using StageWise.Dtos.Course.Request;
using StageWise.Dtos.Course.Response;

namespace StageWise.Services.Business.Interfaces
{
    public interface ICourseService
    {
        Task<CreateCourseResponse> CreateCourseAsync(CreateCourseRequest request);
        Task<GetCourseResponse> GetCourseAsync(int  Id);
    }
}