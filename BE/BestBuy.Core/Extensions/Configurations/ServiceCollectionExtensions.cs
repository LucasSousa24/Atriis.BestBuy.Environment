using BestBuy.Abstractions.Endpoints;
using BestBuy.Abstractions.Models;
using BestBuy.Abstractions.Validators;
using BestBuy.Core.Endpoints;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BestBuy.Core.Extensions.Configurations
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Core Injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // Endpoints
            _ = services.AddScoped<IUserEndpoint, UserEndpoint>();
            _ = services.AddScoped<IProductEndpoint, ProductEndpoint>();

            // Validators
            _ = services.AddScoped<IValidator<User>, UserValidator>();

            return services;
        }
    }
}
