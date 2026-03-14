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

        public async Task DeleteAsync(Class Class)
        {
             _context.Classes.Remove(Class);

        }

        public async Task<List<Class>> GetAllAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class?> GetByIdAsync(int Id)
        {
            return await _context.Classes.Include(c => c.Advisor).Include(c => c.Course!).ThenInclude(a => a.Department!).ThenInclude(d => d.Hod).FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Class?> GetByNameAsync(string Name)
        {
            return await _context.Classes.Include(c => c.Advisor).Include(c => c.Course!).ThenInclude(a => a.Department!).ThenInclude(d => d.Hod).FirstOrDefaultAsync(c => c.Name == Name);
        }

        public Task<List<Class>> GetClassesByCourseIdsAsync(List<int> courseIds)
        {
            return _context.Classes.Where(c => courseIds.Contains(c.CourseId)).Include(c => c.Advisor).Include(c => c.Course!).ThenInclude(a => a.Department!).ThenInclude(d => d.Hod).ToListAsync();
        }

        public async Task<List<Class>> GetClassesByTeacherIdAsync(int teacherId)
        {
            return await _context.Classes.Where(c => c.AdvisorId == teacherId).Include(c => c.Advisor).Include(c => c.Course!).ThenInclude(a => a.Department!).ThenInclude(d => d.Hod).ToListAsync();
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}