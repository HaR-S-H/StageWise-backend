using Microsoft.EntityFrameworkCore;
using StageWise.Data;
using StageWise.Models;
using StageWise.Repositories.Interfaces;

namespace StageWise.Repositories.Implementations
{

    public class HodRepository   : IHodRepository
    {

        private readonly ApplicationDbContext _context;

        public HodRepository(ApplicationDbContext context)    
        {
            _context = context;
        }
        public async Task<Hod?> GetByEmailAsync(string email)
        {
            return await _context.Hods.FirstOrDefaultAsync(h => h.Email == email);
        }
    }
    
}