using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Labb_3___Anropa_databasen__School_.Models;

namespace Labb_3___Anropa_databasen__School_.Data
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveSubject> ActiveSubjects { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Personnel> Personnel { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=DESKTOP-88M6IGA; Initial Catalog=School;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveSubject>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassId");

                entity.Property(e => e.FkPersonnelId).HasColumnName("FK_PersonnelId");

                entity.Property(e => e.FkSubjectId).HasColumnName("FK_SubjectId");

                entity.HasOne(d => d.FkClass)
                    .WithMany()
                    .HasForeignKey(d => d.FkClassId)
                    .HasConstraintName("FK_ActiveSubjects_Class");

                entity.HasOne(d => d.FkPersonnel)
                    .WithMany()
                    .HasForeignKey(d => d.FkPersonnelId)
                    .HasConstraintName("FK_ActiveSubjects_Personnel");

                entity.HasOne(d => d.FkSubject)
                    .WithMany()
                    .HasForeignKey(d => d.FkSubjectId)
                    .HasConstraintName("FK_ActiveSubjects_Subject");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassCode).HasMaxLength(25);

                entity.Property(e => e.ClassName).HasMaxLength(25);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.DateOfGrade).HasColumnType("date");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentId");

                entity.Property(e => e.FkSubjectId).HasColumnName("FK_SubjectId");

                entity.Property(e => e.Grade1).HasColumnName("Grade");

                entity.HasOne(d => d.FkStudent)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.FkStudentId)
                    .HasConstraintName("FK_Grade_Student");

                entity.HasOne(d => d.FkSubject)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.FkSubjectId)
                    .HasConstraintName("FK_Grade_Subject");
            });

            modelBuilder.Entity<Personnel>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(25);

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .HasColumnName("Phone#");

                entity.Property(e => e.Position).HasMaxLength(25);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.City).HasMaxLength(25);

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassId");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .HasColumnName("Phone#");

                entity.Property(e => e.SocialSecurityNumber).HasMaxLength(50);

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FkClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
