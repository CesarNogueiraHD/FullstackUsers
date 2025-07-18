using FullstackUsers.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullstackUsers.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultDatabase");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                connectionString,
                sqlServerOptions =>
                    sqlServerOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null)
            ));

            return services;
        }
    }
}
