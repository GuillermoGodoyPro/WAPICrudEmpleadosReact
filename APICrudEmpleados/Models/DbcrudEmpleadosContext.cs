using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APICrudEmpleados.Models;

public partial class DbcrudEmpleadosContext : DbContext
{
    public DbcrudEmpleadosContext()
    {
    }

    public DbcrudEmpleadosContext(DbContextOptions<DbcrudEmpleadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__A4D6BBFAD8DF1C45");

            entity.ToTable("Empleado");

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
