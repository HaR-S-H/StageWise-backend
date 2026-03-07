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

        public async Task AddAsync(Hod hod)
        {
            await _context.AddAsync(hod);
        }

        public Task DeleteAsync(Hod hod)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Hod>> GetAllAsync()
        {
            return await _context.Hods.ToListAsync();
        }

        public async Task<Hod?> GetByEmailAsync(string email)
        {
            return await _context.Hods.FirstOrDefaultAsync(h => h.Email == email);
        }

        public async Task<Hod?> GetByIdAsync(int Id)
        {
            return await _context.Hods.FirstOrDefaultAsync(h => h.Id == Id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Hod hod)
        {
            _context.Hods.Update(hod);
        }
    }
    
}