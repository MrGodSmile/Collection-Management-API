using CollectionManagementAPI.DataAccess;
using CollectionManagementAPI.DataAccess.Service;
using CollectionManagementAPI.DataAccess.Interfeces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CollectionManagementAPI.Infrastructure;

public static class DataModule
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CollectionsDB");
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddDbContext<CollectionManagementDbContext>(options => { options.UseNpgsql(connectionString); });
        return services;
    }   
}