using Microsoft.EntityFrameworkCore;
using StageWise.Data;
using StageWise.Models;
using StageWise.Repositories.Interfaces;

namespace StageWise.Repositories.Implementations
{

    public class TeacherRepository : ITeacherRepository
    {

        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Teacher teacher)
        {
            await _context.AddAsync(teacher);
        }

        public async Task DeleteAsync(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher?> GetByEmailAsync(string email)
        {
            return await _context.Teachers.FirstOrDefaultAsync(h => h.Email == email);
        }

        public async Task<Teacher?> GetByIdAsync(int Id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(h => h.Id == Id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
        }
    }

}