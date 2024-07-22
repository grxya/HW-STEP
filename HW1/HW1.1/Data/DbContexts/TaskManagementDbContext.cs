using System;
using System.Collections.Generic;
using HW1.Data.Models;
using Microsoft.EntityFrameworkCore;
using Task = HW1.Data.Models.Task;

namespace HW1.Data.DbContexts;

public partial class TaskManagementDbContext : DbContext
{
    public TaskManagementDbContext()
    {
    }

    public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3214EC07360B0FA9");

            entity.Property(e => e.Deadline).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValue("New task");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
