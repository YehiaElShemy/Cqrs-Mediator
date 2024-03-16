using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace Cqrs_Mediator.Application.ApplicatioConfigrations
{
    public static class ApplicationConfigration
    {
        public static IServiceCollection AddApplicationConfigration(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
