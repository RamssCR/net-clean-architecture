namespace CleanArch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DefineValueObjects(modelBuilder);
    }

    private static void DefineValueObjects(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.OwnsOne(task => task.Title, title =>
            {
                title.Property(task => task.Title)
                    .HasColumnName("Title")
                    .IsRequired();
            });
        });
    }
}