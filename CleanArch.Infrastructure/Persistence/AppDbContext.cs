namespace CleanArch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}