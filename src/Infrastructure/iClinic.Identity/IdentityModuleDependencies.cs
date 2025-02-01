using  iClinic.Identity.Contract;
using iClinic.Identity.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace iClinic.Identity
{
    public static class IdentityModuleDependencies
    {
        public static IServiceCollection AddIdentityModuleDependencies(this IServiceCollection services)
        {

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();

            return services;
        }
    }
}
