using System.Security.Cryptography;
using Hacettepe.Application.Authentication.Infrastructure;
using Hacettepe.Application.Database.Maps;
using Hacettepe.Application.Utils;
using Hacettepe.Domain;
using Hacettepe.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

namespace Hacettepe.Application.Database;
public class HacettepeDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly ICurrentUserService _currentUserService;
    
    public HacettepeDbContext(IConfiguration configuration, ICurrentUserService currentUserService)
    {
        _configuration = configuration;
        _currentUserService = currentUserService;
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Page> Pages { get; set; }
    
    public DbSet<Doctor> Doctors { get; set; }
    
    public DbSet<Domain.News> News { get; set; }
    
    public DbSet<Settings> Settings { get; set; }
    
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Audit> Audits { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //ChangeTracker.SetAuditProperties(_currentUserService);
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        //ChangeTracker.SetAuditProperties(_currentUserService);
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        //ChangeTracker.SetAuditProperties(_currentUserService);
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
    
    public override int SaveChanges()
    {
        //ChangeTracker.SetAuditProperties(_currentUserService);
        return base.SaveChanges();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PageMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new MenuItemMap());
        modelBuilder.ApplyConfiguration(new DoctorMap());
        modelBuilder.ApplyConfiguration(new NewsMap());
        modelBuilder.ApplyConfiguration(new SettingsMap());
        
        var salt = new byte[32];
        RandomNumberGenerator.Create().GetBytes(salt);
        var password = Hasher.Hash("Admin123!", salt);
        
        //modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "Admin", Email = "admin@admin.com", Password = password, Salt = salt, Role = Roles.Admin, IsActive = true, CreatedBy = "Admin", CreatedDate = DateTime.UtcNow });
    }   
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention();
}