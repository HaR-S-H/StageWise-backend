using Microsoft.EntityFrameworkCore;
using StageWise.Data;
using StageWise.Models;
using StageWise.Repositories.Interfaces;

namespace StageWise.Repositories.Implementations
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _context;
        public ClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Class Class)
        {
            await _context.Classes.AddAsync(Class);
        }

        public Task DeleteAsync(Class Class)
        {
            throw new NotImplementedException();
        }

        public Task<List<Class>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Class?> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Class?> GetByNameAsync(string Name)
        {
            return await _context.Classes.Include(c => c.Advisor).Include(c => c.Course!).ThenInclude(a=>a.Department!).ThenInclude(d=>d.Hod).FirstOrDefaultAsync(c => c.Name == Name);
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}