using Microsoft.EntityFrameworkCore;
using Thunder.ToDoList.Domain.Entities;
using Thunder.ToDoList.Infra.Data.Configurations;

namespace Thunder.ToDoList.Infra.Data.Context;

public class AppDbContext : DbContext
{
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskItemConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
