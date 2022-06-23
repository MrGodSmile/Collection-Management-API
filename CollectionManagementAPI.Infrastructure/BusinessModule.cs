using CollectionManagementAPI.Entity;
using CollectionManagementAPI.Service.Interfeces;
using CollectionManagementAPI.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CollectionManagementAPI.Infrastructure;

public static class BusinessModule
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ICollectionService, CollectionService>();
        return services;
    }
}