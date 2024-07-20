using BestBuy.Abstractions.Storages;
using BestBuy.EFCore.Storages;
using Microsoft.Extensions.DependencyInjection;

namespace BestBuy.EFCore.Extensions.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            // Storage
            _ = services.AddSingleton<IUserStorage, UserInMemoryStorage>();

            return services;
        }
    }
}
