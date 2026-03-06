using StageWise.Models;
namespace StageWise.Repositories.Interfaces

{
    public interface IHodRepository
    {

        Task<Hod?> GetByEmailAsync(string email);
        Task AddAsync(Hod hod);
        Task<List<Hod>> GetAllAsync();
        Task DeleteAsync(Hod hod);
        Task UpdateAsync(Hod hod);
        Task SaveAsync();
    }
}