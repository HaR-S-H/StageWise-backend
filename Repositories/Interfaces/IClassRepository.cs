using StageWise.Models;

namespace StageWise.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<Class?> GetByNameAsync(string Name);
        Task<Class?> GetByIdAsync(int Id);
        Task<List<Class>> GetAllAsync();
        Task DeleteAsync(Class Class);
        Task SaveAsync();
        Task AddAsync(Class Class);
    }
}