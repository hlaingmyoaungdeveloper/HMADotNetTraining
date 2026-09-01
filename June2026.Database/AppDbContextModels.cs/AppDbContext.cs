using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace June2026.Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEnrollment> TblEnrollments { get; set; }

    public virtual DbSet<TblSubClass> TblSubClasses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEnrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId);

            entity.ToTable("Tbl_Enrollment", tb => tb.HasTrigger("trg_UpdateEnrollmentModifiedTime"));

            entity.Property(e => e.CreatedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FatherName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentInfo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentContact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.SubClass).WithMany(p => p.TblEnrollments)
                .HasForeignKey(d => d.SubClassId)
                .HasConstraintName("FK_Tbl_Enrollment_Tbl_SubClass");
        });

        modelBuilder.Entity<TblSubClass>(entity =>
        {
            entity.HasKey(e => e.SubClassId);

            entity.ToTable("Tbl_SubClass", tb => tb.HasTrigger("trg_UpdateSubClassModifiedTime"));

            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
