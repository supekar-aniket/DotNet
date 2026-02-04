using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _27_binding_dropdownlist_with_database.Models;

public partial class BindingDropdownlistWithDatabaseContext : DbContext
{
    public BindingDropdownlistWithDatabaseContext()
    {
    }

    public BindingDropdownlistWithDatabaseContext(DbContextOptions<BindingDropdownlistWithDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PaymentMethods");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PaymentMethod).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
