using AutoMapper;
using StageWise.Dtos.Stage.Request;
using StageWise.Dtos.Stage.Response;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class StageService : IStageService
    {
        private readonly IStageRepository _stageRepository;
        private readonly IMapper _mapper;
        public StageService(IStageRepository stageRepository, IMapper mapper)
        {
            _stageRepository = stageRepository;
            _mapper = mapper;
        }
        public async Task<CreateStageResponse> CreateStageAsync(CreateStageRequest request)
        {
            var stage = _mapper.Map<ProjectStage>(request);
            await _stageRepository.AddAsync(stage);
            await _stageRepository.SaveAsync();
            return new CreateStageResponse { Success = true, Message = "Stage created successfully" };
        }
    }
}