using StageWise.Models;

namespace StageWise.Repositories.Interfaces
{
    public interface IStageRepository{
        Task AddAsync(ProjectStage stage);
        Task SaveAsync();
    }
}