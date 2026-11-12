namespace Keeper_AssetManager.Data;
using Keeper_AssetManager.Models;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Assets.Any())
        {
            return;
        }

        var regions = new Region[]
        {
            new Region { Name = "US-East (Virginia)", Code = "us-east-1" },
            new Region { Name = "EU-West (Ireland)", Code = "eu-west-1" },
            new Region { Name = "AP-South (Singapore)", Code = "ap-southeast-1" },
        };
        context.Regions.AddRange(regions);
        context.SaveChanges();

        var users = new User[]
        {
            new User
            {
                Name = "James Stirling", Email = "Stirling.admin@FragInc.com",
                Password = Utils.HashPassword("mypassword123"), Role = "Admin"
            },
            new User
            {
                Name = "Amanda Gordon", Email = "amanda.gordon@FragInc.com",
                Password = Utils.HashPassword("coolpassword123"), Role = "Engineer"
            }
        };
        context.Users.AddRange(users);
        context.SaveChanges();

        var assets = new Asset[]
        {
            new Asset
            {
                Name = "prod-web-us-east-01",
                Category = "IT Infrastructure",
                Type = "Virtual Machine",
                Status = true,
                RegionId = regions[0].RegionId,
                OwnerId = users[0].UserId
            },
            new Asset
            {
                Name = "db-postgres-primary",
                Category = "IT Infrastructure",
                Type = "Database",
                Status = true,
                RegionId = regions[1].RegionId,
                OwnerId = users[1].UserId
            }
        };
        context.Assets.AddRange(assets);
        context.SaveChanges();
    }
}