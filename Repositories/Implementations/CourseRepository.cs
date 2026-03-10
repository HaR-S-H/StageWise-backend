using Microsoft.EntityFrameworkCore;
using StageWise.Data;
using StageWise.Models;
using StageWise.Repositories.Interfaces;

namespace StageWise.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
        }

        public async Task DeleteAsync(Course course)
        {
             _context.Courses.Remove(course);
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(c=>c.Department!).ThenInclude(d=>d.Hod).ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int Id)
        {
            return await _context.Courses
       .Include(c => c.Department!)
       .ThenInclude(d => d.Hod)
       .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Course?> GetByNameAsync(string Name)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Name == Name);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}