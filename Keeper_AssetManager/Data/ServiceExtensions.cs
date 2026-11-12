using Microsoft.EntityFrameworkCore;

namespace Keeper_AssetManager.Data;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=assetmanager.db"));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}