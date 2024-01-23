using AndradeProducts.API.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AndradeProducts.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerConfig();
            services.ResolveDependencies();
            services.AddWebApiConfiguration();
            services.AddContextConfiguration(Configuration);
            services.AddJwtConfiguration(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseExceptionHandler("/error");
            app.UseWebApiConfiguration(env);
            app.UseSecurityConfiguration();
            app.UseSwaggerConfig(env, provider);
        }
    }
}
