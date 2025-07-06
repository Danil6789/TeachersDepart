using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeachersDepart.Models;

namespace TeachersDepart.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicDegree> AcademicDegrees { get; set; }

    public virtual DbSet<AcademicTitle> AcademicTitles { get; set; }

    public virtual DbSet<ClassType> ClassTypes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<StudentGroup> StudentGroups { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeachersGroupDiscipline> TeacherGroupDisciplines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sotniPC;Database=Teachers_department;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicDegree>(entity =>
        {
            entity.HasKey(e => e.AcademicDegreeId).HasName("PK__Academic__F51BC4E5E2FEC09A");

            entity.ToTable("AcademicDegree");

            entity.HasIndex(e => e.AcademicDegreeName, "UQ__Academic__14BAA289C815A190").IsUnique();

            entity.Property(e => e.AcademicDegreeId).ValueGeneratedNever();
            entity.Property(e => e.AcademicDegreeName)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AcademicTitle>(entity =>
        {
            entity.HasKey(e => e.AcademicTitleId).HasName("PK__Academic__D92C11C601A62FE2");

            entity.ToTable("AcademicTitle");

            entity.HasIndex(e => e.AcademicTitleName, "UQ__Academic__21DEEDF860431976").IsUnique();

            entity.Property(e => e.AcademicTitleId).ValueGeneratedNever();
            entity.Property(e => e.AcademicTitleName)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClassType>(entity =>
        {
            entity.HasKey(e => e.ClassTypeId).HasName("PK__ClassTyp__9AB21373A35BEEA4");

            entity.ToTable("ClassType");

            entity.HasIndex(e => e.ClassTypeName, "UQ__ClassTyp__184FD1433467F80F").IsUnique();

            entity.Property(e => e.ClassTypeId).ValueGeneratedNever();
            entity.Property(e => e.ClassTypeName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseName).HasName("PK__Course__9526E27611E3B814");

            entity.ToTable("Course");

            entity.Property(e => e.CourseName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AssessmentType)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__60BB9A7985EF9852");

            entity.ToTable("Position");

            entity.HasIndex(e => e.PositionName, "UQ__Position__E46AEF423CFEEB96").IsUnique();

            entity.Property(e => e.PositionId).ValueGeneratedNever();
            entity.Property(e => e.PositionName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.SpecializationId).HasName("PK__Speciali__5809D86F7326B4A0");

            entity.ToTable("Specialization");

            entity.HasIndex(e => e.SpecializationName, "UQ__Speciali__08A8EB9EC3BBF680").IsUnique();

            entity.Property(e => e.SpecializationId).ValueGeneratedNever();
            entity.Property(e => e.SpecializationName)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentGroup>(entity =>
        {
            entity.HasKey(e => e.GroupNumber).HasName("PK__StudentG__8BA4751B13E0B0FE");

            entity.ToTable("StudentGroup");

            entity.Property(e => e.GroupNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Specialization).WithMany(p => p.StudentGroups)
                .HasForeignKey(d => d.SpecializationId)
                .HasConstraintName("FK__StudentGr__Speci__4D94879B");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherPassportNumber).HasName("PK__Teacher__EEFB93B10D9C50C5");

            entity.ToTable("Teacher");

            entity.HasIndex(e => new { e.FullName, e.BirthDate }, "AK1_Teacher").IsUnique();

            entity.Property(e => e.TeacherPassportNumber).ValueGeneratedNever();
            entity.Property(e => e.FullName)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.AcademicDegree).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.AcademicDegreeId)
                .HasConstraintName("FK__Teacher__Academi__52593CB8");

            entity.HasOne(d => d.AcademicTitle).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.AcademicTitleId)
                .HasConstraintName("FK__Teacher__Academi__5165187F");

            entity.HasOne(d => d.Position).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Teacher__Positio__534D60F1");
        });

        modelBuilder.Entity<TeachersGroupDiscipline>(entity =>
        {
            entity.HasKey(e => new { e.TeacherPassportNumber, e.CourseName, e.ClassTypeId, e.GroupNumber }).HasName("PR_Discipline");

            entity.ToTable("TeacherGroupDiscipline");

            entity.Property(e => e.CourseName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.GroupNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ClassType).WithMany(p => p.TeacherGroupDisciplines)
                .HasForeignKey(d => d.ClassTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeacherGr__Class__5812160E");

            entity.HasOne(d => d.CourseNameNavigation).WithMany(p => p.TeacherGroupDisciplines)
                .HasForeignKey(d => d.CourseName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeacherGr__Cours__571DF1D5");

            entity.HasOne(d => d.GroupNumberNavigation).WithMany(p => p.TeacherGroupDisciplines)
                .HasForeignKey(d => d.GroupNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeacherGr__Group__59063A47");

            entity.HasOne(d => d.TeacherPassportNumberNavigation).WithMany(p => p.TeacherGroupDisciplines)
                .HasForeignKey(d => d.TeacherPassportNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeacherGr__Teach__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
