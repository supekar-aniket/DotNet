using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _34_web_API_CURD_with_Database.Models;

public partial class WebApiwithCrudDatabaseContext : DbContext
{
    public WebApiwithCrudDatabaseContext()
    {
    }

    public WebApiwithCrudDatabaseContext(DbContextOptions<WebApiwithCrudDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Standard).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
