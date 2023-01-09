using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Models;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=connectionString:Company");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_department");

            entity.ToTable("department", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_employee");

            entity.ToTable("employee", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Designation)
                .HasMaxLength(25)
                .HasColumnName("designation");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Departmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
