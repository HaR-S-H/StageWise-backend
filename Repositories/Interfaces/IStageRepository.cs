using StageWise.Models;

namespace StageWise.Repositories.Interfaces
{
    public interface IStageRepository{
        Task AddAsync(ProjectStage stage);
        Task<ProjectStage?> GetByIdAsync(int id);
        Task DeleteAsync(ProjectStage stage);
        Task SaveAsync();
    }
}