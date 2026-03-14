using StageWise.Models;

namespace StageWise.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetByNameAsync(string Name);
        Task AddAsync(Department department);
        Task<Department?> GetByIdAsync(int Id);
        Task<List<Department>> GetAllAsync();
        Task DeleteAsync(Department department);
        Task<Department?> GetByHodIdAsync(int hodId);
        Task SaveAsync();
    }
}