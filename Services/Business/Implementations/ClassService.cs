using AutoMapper;
using StageWise.Dtos.Class.Request;
using StageWise.Dtos.Class.Response;
using StageWise.Helpers.Exceptions;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class ClassService:IClassService
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository,IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<CreateClassResponse> CreateClassAsync(CreateClassRequest request)
        {
            var existingClass =await _classRepository.GetByNameAsync(request.Name);
            if (existingClass != null) throw new AppException("Class already exists", 409);
            var @class = _mapper.Map<Class>(request);
            await _classRepository.AddAsync(@class);
            await _classRepository.SaveAsync();
            return new CreateClassResponse
            {
                Success = true,
                Message = "Class created successfully",
            };
        }

        public async Task<GetClassResponse> GetClassAsync(int Id)
        {
            var @class = await _classRepository.GetByIdAsync(Id);
            if (@class == null) throw new AppException("Class not found", 404);
            return _mapper.Map<GetClassResponse>(@class);
        }

        public async Task<List<GetClassResponse>> GetClassesAsync()
        {
            var classes = await _classRepository.GetAllAsync();
            if (classes.Count == 0) throw new AppException("No classes found", 404);
            return _mapper.Map<List<GetClassResponse>>(classes);
        }
    }
}