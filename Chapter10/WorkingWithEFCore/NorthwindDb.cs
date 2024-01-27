
using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace WorkingWithEFCore;

public class NorthwindDb : DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        string databaseFile = "Northwind.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);
        string connectionString = $"Data Source={path}";
        WriteLine(connectionString);
        optionsBuilder.UseSqlite(connectionString);
        optionsBuilder.LogTo(WriteLine,new[]{RelationalEventId.CommandExecuting})
        #if DEBUG
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
        #endif
        ;
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(15);
        modelBuilder.Entity<Product>()
            .Property(p => p.Cost)
            .HasConversion<double>();
        base.OnModelCreating(modelBuilder);
    }
}
