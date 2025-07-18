using FullstackUsers.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace FullstackUsers.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(ApplicationModule)));
            services.AddAutoMapper(config => config.AddProfile<Mapper>());

            return services;
        }
    }
}
