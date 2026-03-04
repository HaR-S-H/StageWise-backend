using StageWise.Models;
namespace StageWise.Repositories.Interfaces

{
    public interface IHodRepository
    {

        Task<Hod?> GetByEmailAsync(string email);
        
    }
}