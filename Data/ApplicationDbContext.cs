using Microsoft.EntityFrameworkCore;
using StageWise.Models;
namespace StageWise.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<TeacherDetail> TeacherDetails { get; set; }
        public DbSet<HODDetail> HODDetails { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<StageMaster> StageMasters { get; set; }
        public DbSet<ProjectStage> ProjectStages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupStageProgress> GroupStageProgress { get; set; }
        public DbSet<StageDocument> StageDocuments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Department → HOD → User
            modelBuilder.Entity<Department>()
                .HasOne(d => d.HOD)
                .WithMany()
                .HasForeignKey(d => d.HodId)
                .OnDelete(DeleteBehavior.Restrict);

            // Course → Advisor → User
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Advisor)
                .WithMany()
                .HasForeignKey(c => c.AdvisorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Group → Mentor → User
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Mentor)
                .WithMany()
                .HasForeignKey(g => g.MentorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Group → Captain → User
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Captain)
                .WithMany()
                .HasForeignKey(g => g.CaptainId)
                .OnDelete(DeleteBehavior.Restrict);

            // TeacherDetails → User
            modelBuilder.Entity<TeacherDetail>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                   modelBuilder.Entity<GroupStageProgress>()
        .HasOne(gsp => gsp.Group)
        .WithMany()
        .HasForeignKey(gsp => gsp.GroupId)
        .OnDelete(DeleteBehavior.Cascade); // keep cascade

    modelBuilder.Entity<GroupStageProgress>()
        .HasOne(gsp => gsp.ProjectStage)
        .WithMany()
        .HasForeignKey(gsp => gsp.ProjectStageId)
        .OnDelete(DeleteBehavior.Restrict); // fix error
        }

    }

}

