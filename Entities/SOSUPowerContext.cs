using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class SOSUPowerContext : DbContext
{
    public SOSUPowerContext()
    {
    }

    public SOSUPowerContext(DbContextOptions<SOSUPowerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Resident> Residents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SOSUPower5000;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Assignme__3214EC079D897AB3");

            entity.ToTable("Assignment");

            entity.Property(e => e.ActualEndDate).HasColumnType("datetime");
            entity.Property(e => e.ExpectedEndDate).HasColumnType("datetime");
            entity.Property(e => e.Notes).HasMaxLength(150);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Resident).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.ResidentId)
                .HasConstraintName("FK_Assignments_Residents");

            entity.HasOne(d => d.SolvedByNavigation).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.SolvedBy)
                .HasConstraintName("FK_Assignments_Employee");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC071536524F");

            entity.ToTable("Employee");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(50);
        });

        modelBuilder.Entity<Resident>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resident__3214EC07B6A0B1BD");

            entity.ToTable("Resident");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.DemiseDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
