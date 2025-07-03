using Microsoft.EntityFrameworkCore;
using CollegeERPPortal.Domain.Entities;

namespace CollegeERPPortal.Persistence.Context
{
    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  base.OnModelCreating(modelBuilder);

                  // STUDENT Configuration
                  modelBuilder.Entity<Student>(entity =>
                  {
                        entity.ToTable("STUDENTS");

                        entity.HasKey(e => e.Id);

                        entity.Property(e => e.Id)
                        .HasColumnName("ID")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                        entity.Property(e => e.Name)
                        .HasColumnName("NAME")
                        .HasColumnType("NVARCHAR2(100)")
                        .IsRequired();

                        entity.Property(e => e.Email)
                        .HasColumnName("EMAIL")
                        .HasColumnType("NVARCHAR2(100)")
                        .IsRequired();

                        entity.Property(e => e.Course)
                        .HasColumnName("COURSE")
                        .HasColumnType("NVARCHAR2(100)")
                        .IsRequired();

                        entity.Property(e => e.DOB)
                        .HasColumnName("DOB")
                        .HasColumnType("DATE")
                        .IsRequired();
                  });

                  // FACULTY Configuration
                  modelBuilder.Entity<Faculty>(entity =>
                  {
                        entity.ToTable("FACULTIES");

                        entity.HasKey(f => f.Id);

                        entity.Property(f => f.Id)
                        .HasColumnName("ID")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                        entity.Property(f => f.Name)
                        .HasColumnName("NAME")
                        .HasColumnType("NVARCHAR2(100)")
                        .IsRequired();

                        entity.Property(f => f.Department)
                        .HasColumnName("DEPARTMENT")
                        .HasColumnType("NVARCHAR2(100)")
                        .IsRequired();

                        entity.Property(f => f.Email)
                        .HasColumnName("EMAIL")
                        .HasColumnType("NVARCHAR2(100)")
                        .IsRequired();

                        entity.Property(f => f.JoinDate)
                        .HasColumnName("JOINDATE")
                        .HasColumnType("DATE")
                        .IsRequired();
                  });
            }
    }
}
