namespace CleanArch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

public class AppDbContext : DbContext
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}