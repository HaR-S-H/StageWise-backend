using StageWise.Models;

namespace StageWise.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetByNameAsync(string Name);
        Task AddAsync(Department department);
        Task SaveAsync();
    }
}