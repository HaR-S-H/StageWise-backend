using StageWise.Dtos.Department.Request;
using StageWise.Dtos.Department.Response;

namespace StageWise.Services.Business.Interfaces
{
    public interface IDepartmentService
    {
        Task<CreateDepartmentResponse> CreateDepartmentAsync(CreateDepartmentRequest request);
        Task<GetDepartmentResponse> GetDepartmentAsync(int Id);
    }
}