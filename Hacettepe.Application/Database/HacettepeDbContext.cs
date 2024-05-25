using Hacettepe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hacettepe.Application.Database;
public class HacettepeDbContext : DbContext
{
    protected readonly IConfiguration _configuration;
    
    public HacettepeDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "Admin", Email = "admin@admin.com", Password = "admin"});
    }   
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention();
}