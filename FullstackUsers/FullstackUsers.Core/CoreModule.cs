using FullstackUsers.Core.Options;
using FullstackUsers.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullstackUsers.Core
{
    public static class CoreModule
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PrivateKeysOptions>(configuration.GetSection(PrivateKeysOptions.PrivateKeys));
            services.AddTransient<TokenService>();

            return services;
        }
    }
}
