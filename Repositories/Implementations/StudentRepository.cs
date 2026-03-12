using Microsoft.EntityFrameworkCore;
using StageWise.Data;
using StageWise.Models;
using StageWise.Repositories.Interfaces;

namespace StageWise.Repositories.Implementations

{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student student)
        {
           await _context.Students.AddAsync(student);
        }

        public async Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
        }

        public Task<List<Student>> GetAllAsync()
        {
            return _context.Students
                .Include(s => s.Class!)
                    .ThenInclude(c => c.Advisor)
                .Include(s => s.Class!)
                    .ThenInclude(c => c.Course!)
                        .ThenInclude(c => c.Department!)
                            .ThenInclude(d => d.Hod)
                .ToListAsync();
        }

        public async Task<Student?> GetByEmailAsync(string email)
        {
            return await _context.Students
     .Include(s => s.Class!)
         .ThenInclude(c => c.Advisor)
     .Include(s => s.Class!)
         .ThenInclude(c => c.Course!)
             .ThenInclude(c => c.Department!)
                 .ThenInclude(d => d.Hod)
     .FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<Student?> GetByIdAsync(int Id)
        {
            return await _context.Students.Include(s=>s.Class!).ThenInclude(c=>c.Course!).ThenInclude(c=>c.Department!).ThenInclude(c=>c.Hod).Include(c=>c.Class!).ThenInclude(c=>c.Advisor).Include(s=>s.Class).FirstOrDefaultAsync(s => s.Id == Id);
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}