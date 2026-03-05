using Microsoft.EntityFrameworkCore;
using StageWise.Data;
using StageWise.Models;
using StageWise.Repositories.Interfaces;

namespace StageWise.Repositories.Implementations
{

    public class AdminRepository   : IAdminRepository
    {

        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)    
        {
            _context = context;
        }
        public async Task<Admin?> GetByEmailAsync(string email)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.Email == email);
        }
         public async Task AddAsync(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
    
}