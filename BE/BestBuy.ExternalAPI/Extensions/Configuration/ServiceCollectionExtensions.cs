using BestBuy.Abstractions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BestBuy.ExternalAPI.Extensions.Configuration
{
    /// <summary>
    /// Service Collection Extensions
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Mdm Service
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddExternalAPIService(this IServiceCollection services)
        {
            _ = services.AddHttpClient<IExternalAPI, BestBuy.ExternalAPI.Services.ExternalAPI>();
            _ = services.AddScoped<IExternalAPI, BestBuy.ExternalAPI.Services.ExternalAPI>();
            return services;
        }
    }
}
