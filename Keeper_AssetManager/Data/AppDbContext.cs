using Microsoft.EntityFrameworkCore;
using Keeper_AssetManager.Models;

namespace Keeper_AssetManager.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

    public DbSet<User> Users => Set<User>();
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<ApiKey> ApiKeys => Set<ApiKey>();
    public DbSet<Region> Regions => Set<Region>();
    public DbSet<AuditTrail> AuditTrails => Set<AuditTrail>();
}