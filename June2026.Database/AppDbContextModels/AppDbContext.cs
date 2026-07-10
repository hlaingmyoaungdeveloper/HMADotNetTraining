using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace June2026.Database.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblStaff> TblStaffs { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ASPIERLITE16;Database=June2026Db;User Id = sa;Password = sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId);

            entity.ToTable("Tbl_Staff");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.StaffName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("Tbl_Student");

            entity.Property(e => e.DateOfBirthday).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
