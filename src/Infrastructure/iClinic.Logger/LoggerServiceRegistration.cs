using iClinic.Logger.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iClinic.Logger
{
    public static class LoggerServiceRegistration
    {
        public static IServiceCollection AddLoggerServices(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddSingleton<ILoggerManager, LoggerManager>();
            return services;
        }
    }
}
