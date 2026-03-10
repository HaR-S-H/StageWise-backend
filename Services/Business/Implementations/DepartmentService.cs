using AutoMapper;
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
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IHodRepository hodRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _hodRepository = hodRepository;
            _mapper = mapper;
        }
        public async Task<CreateDepartmentResponse> CreateDepartmentAsync(CreateDepartmentRequest request)
        {
            var existingDepartment = await _departmentRepository.GetByNameAsync(request.Name);
            if (existingDepartment != null) throw new AppException("Department already exists", 409);
            var existingHod = await _hodRepository.GetByIdAsync(request.HodId);
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

        public async Task<GetDepartmentResponse> GetDepartmentAsync(int Id)
        {
            var deparment = await _departmentRepository.GetByIdAsync(Id);
            if (deparment == null) throw new AppException("Department not found", 404);
            return _mapper.Map<GetDepartmentResponse>(deparment);

        }
        public async Task<List<GetDepartmentResponse>> GetDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            if (departments.Count == 0) throw new AppException("No departments found", 404);
            return _mapper.Map<List<GetDepartmentResponse>>(departments);
        }
        public async Task<DeleteDepartmentResponse> DeleteDepartmentAsync(int Id)
        {
            var department = await _departmentRepository.GetByIdAsync(Id);
            if (department == null) throw new AppException("Department not found", 404);
            await _departmentRepository.DeleteAsync(department);
            await _departmentRepository.SaveAsync();
            return new DeleteDepartmentResponse { Success = true, Message = "Department deleted successfully" };
        }

    }
}