using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public string? ConnectionString { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentTeacher> StudentTeachers { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public AppDbContext()
        {
            ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=StudentManagement;Integrated Security=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString ?? throw new ArgumentException());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(x => x.StudentId);
                entity.HasAlternateKey(x => x.StudentEnrollment);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(x => x.TeacherId);
                entity.HasAlternateKey(x => x.TeacherEnrolledId);
            });

            modelBuilder.Entity<StudentTeacher>()
                .HasKey(st => new { st.StudentId, st.TeacherId });

            modelBuilder.Entity<StudentTeacher>()
                .HasOne(st => st.Student)
                .WithMany(st => st.StudentTeachers)
                .HasForeignKey(st => st.StudentId);

            modelBuilder.Entity<StudentTeacher>()
                .HasOne(st => st.Teacher)
                .WithMany(st => st.StudentTeachers)
                .HasForeignKey(st => st.TeacherId);

            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StundentId, ss.SubjectId });

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(ss => ss.StudentSubjects)
                .HasForeignKey(ss => ss.StundentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(ss => ss.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Grades)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Grades)
                .WithOne(s => s.Subject)
                .HasForeignKey(s => s.SubjectId);

            modelBuilder.Entity<Grade>()
                .HasIndex(g => g.SubjectId)
                .IsUnique(false);
        }
    }
}
