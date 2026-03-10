using StageWise.Dtos.Department.Request;
using StageWise.Dtos.Department.Response;
using StageWise.Helpers.Exceptions;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IHodRepository _hodRepository;
        public DepartmentService(IDepartmentRepository departmentRepository,IHodRepository hodRepository)
        {
            _departmentRepository = departmentRepository;
            _hodRepository = hodRepository;
        }
        public async Task<CreateDepartmentResponse> CreateDepartmentAsync(CreateDepartmentRequest request)
        {
            var existingDepartment = await _departmentRepository.GetByNameAsync(request.Name);
            if (existingDepartment != null) throw new AppException("Department already exists", 409);
            var existingHod=await _hodRepository.GetByIdAsync(request.HodId);
            if (existingHod == null) throw new AppException("Hod not found", 404);
            var department = new Department
            {
                Name = request.Name,
                HodId = request.HodId,
            };
            await _departmentRepository.AddAsync(department);
            await _departmentRepository.SaveAsync();
            return new CreateDepartmentResponse
            {
                Success = true,
                Message = "Department created successfully",
            };
            
        }
    }
}