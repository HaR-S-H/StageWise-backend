using StageWise.Models;
namespace StageWise.Repositories.Interfaces

{
    public interface IAdminRepository
    {

        Task<Admin?> GetByEmailAsync(string email);
        Task AddAsync(Admin admin);
        Task<List<Admin>> GetAllAsync();
        Task DeleteAsync(Admin admin);
        Task UpdateAsync(Admin admin);
        Task SaveAsync();
    }
}