using iClinic.Infrastructure.Data;
using iClinic.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iClinic.Infrastructure
{
    public static class InfrastructureModuleDependencies
    {
        public static IServiceCollection AddInfrastructureModuleDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("default"));
            });

            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
