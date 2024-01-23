using AndradeProducts.Domain.Builders.User;
using AndradeProducts.Domain.v1.Interfaces.Builders;
using AndradeProducts.Domain.v1.Interfaces.Repositories;
using AndradeProducts.Domain.v1.Interfaces.Services;
using AndradeProducts.Domain.v1.Services;
using AndradeProducts.Infrastructure.v1.Repositories;
using Logistics.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AndradeProducts.API.Configurations
{
    public static class DependencyConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Work Interfaces
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();

            // Builders
            services.AddScoped<ILoginResponseBuilder, LoginResponseBuilder>();

            return services;
        }
    }
}

