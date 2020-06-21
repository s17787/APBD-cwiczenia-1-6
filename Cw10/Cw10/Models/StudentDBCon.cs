using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.Models
{
    public class StudentDBCon : DbContext
    {   
    public StudentDBCon()
    {
    }
    public StudentDBCon(DbContextOptions<StudentDBCon> op)
        : base(op)
    {
    }
    public virtual DbSet<Enrollment> Enrollment { get; set; }
    public virtual DbSet<Student> Student { get; set; }
    public virtual DbSet<Studies> Studies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder DbContextOptionsBuilder)
    {
        base.OnConfiguring(DbContextOptionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.IdEnrollment).HasName("Enrollment_PK");

            entity.Property(e => e.IdEnrollment).ValueGeneratedNever();
            entity.Property(e => e.StartDate).HasColumnType("Date");
            entity.HasOne(d => d.Studies).WithMany(p => p.Enrollments).HasForeignKey(d => d.IdStudy).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Enrollment_Studies");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IndexNumber).HasName("Student_PK");

            entity.Property(e => e.IndexNumber).HasMaxLength(200);
            entity.Property(e => e.BirthDate).HasColumnType("Date");

            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(200);

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Students).HasForeignKey(d => d.IdEnrollment).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Student_Enrollment");
        });

        modelBuilder.Entity<Studies>(entity =>
        {
            entity.HasKey(e => e.IdStudy).HasName("Studies_PK");
            entity.Property(e => e.IdStudy).ValueGeneratedNever();

            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
        });
    }

    }
}
