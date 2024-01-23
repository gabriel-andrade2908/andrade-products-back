using AndradeProducts.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AndradeProducts.API.Configurations
{
    public static class ContextConfig
    {
        public static IServiceCollection AddContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductsContext>(options => options
            .UseSqlServer(configuration.GetConnectionString("Products")));

            return services;
        }
    }
}
