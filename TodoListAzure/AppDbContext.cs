using Microsoft.EntityFrameworkCore;
using TodoListAzure.Models;

namespace TodoListAzure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    public DbSet<Todo>  Todos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Todo>()
            .Property(t => t.description).IsRequired();

        modelBuilder.Entity<Todo>()
            .HasKey(t => t.id);

        modelBuilder.Entity<Todo>()
            .Property(t => t.id)
            .ValueGeneratedOnAdd();
    }
}