using Microsoft.EntityFrameworkCore;
using StageWise.Models;

namespace StageWise.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Hod> Hods { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStage> ProjectStages { get; set; }

        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<StudentGroupMember> StudentGroupMembers { get; set; }

        public DbSet<GroupStageProgress> GroupStageProgresses { get; set; }
        public DbSet<GroupStageDocument> GroupStageDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔥 GLOBAL RULE: Disable cascade everywhere
            foreach (var relationship in modelBuilder.Model
                         .GetEntityTypes()
                         .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // ===============================
            // ENABLE CASCADE ONLY WHERE SAFE
            // ===============================

            // Department -> Course
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany()
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Course -> Class
            modelBuilder.Entity<Class>()
                .HasOne(c => c.Course)
                .WithMany()
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Class -> Project
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Class)
                .WithMany()
                .HasForeignKey(p => p.ClassId)
                .OnDelete(DeleteBehavior.Cascade);

            // Project -> ProjectStage
            modelBuilder.Entity<ProjectStage>()
                .HasOne(ps => ps.Project)
                .WithMany(p => p.Stages)
                .HasForeignKey(ps => ps.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Project -> StudentGroup
            modelBuilder.Entity<StudentGroup>()
                .HasOne(sg => sg.Project)
                .WithMany()
                .HasForeignKey(sg => sg.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // StudentGroup -> Members
            modelBuilder.Entity<StudentGroupMember>()
                .HasOne(m => m.StudentGroup)
                .WithMany(sg => sg.Members)
                .HasForeignKey(m => m.StudentGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // StudentGroup -> StageProgress
            modelBuilder.Entity<GroupStageProgress>()
                .HasOne(g => g.StudentGroup)
                .WithMany(sg => sg.StageProgress)
                .HasForeignKey(g => g.StudentGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // StageProgress -> Documents
            modelBuilder.Entity<GroupStageDocument>()
                .HasOne(d => d.GroupStageProgress)
                .WithMany(g => g.Documents)
                .HasForeignKey(d => d.GroupStageProgressId)
                .OnDelete(DeleteBehavior.Cascade);

            // ===============================
            // ALL OTHERS REMAIN RESTRICT
            // ===============================

            // Class -> Advisor
            modelBuilder.Entity<Class>()
                .HasOne(c => c.Advisor)
                .WithMany()
                .HasForeignKey(c => c.AdvisorId)
                .OnDelete(DeleteBehavior.Restrict);

            // StudentGroup -> Mentor
            modelBuilder.Entity<StudentGroup>()
                .HasOne(sg => sg.Mentor)
                .WithMany()
                .HasForeignKey(sg => sg.MentorId)
                .OnDelete(DeleteBehavior.Restrict);

            // StudentGroupMember -> Student
            modelBuilder.Entity<StudentGroupMember>()
                .HasOne(m => m.Student)
                .WithMany()
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // GroupStageProgress -> ProjectStage
            modelBuilder.Entity<GroupStageProgress>()
                .HasOne(g => g.ProjectStage)
                .WithMany()
                .HasForeignKey(g => g.ProjectStageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Hod -> Department
           
        }

    }
}