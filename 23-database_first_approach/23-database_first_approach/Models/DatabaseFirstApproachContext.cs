using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _23_database_first_approach.Models;

public partial class DatabaseFirstApproachContext : DbContext
{
    public DatabaseFirstApproachContext()
    {
    }

    public DatabaseFirstApproachContext(DbContextOptions<DatabaseFirstApproachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
