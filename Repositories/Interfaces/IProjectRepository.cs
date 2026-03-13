using StageWise.Models;

namespace StageWise.Repositories.Interfaces
{
   public interface IProjectRepository
    {
        Task AddAsync(Project project);
        Task<Project?> GetByIdAsync(int Id);
        Task SaveAsync();
    }
}