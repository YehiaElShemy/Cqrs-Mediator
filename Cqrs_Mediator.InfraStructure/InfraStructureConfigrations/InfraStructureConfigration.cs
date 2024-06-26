﻿using Cqrs_Mediator.Application.Abstractions;
using Cqrs_Mediator.Application.Abstractions.ProductContract;
using Cqrs_Mediator.Application.Abstractions.RepositoryContract;
using Cqrs_Mediator.InfraStructure.DataContext;
using Cqrs_Mediator.InfraStructure.InfraStructureConfigrations.SettingSystem;
using Cqrs_Mediator.InfraStructure.Repositoryimplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Cqrs_Mediator.InfraStructure.InfraStructureConfigrations
{
    public static class InfraStructureConfigration
    {
        public static IServiceCollection AddInfraStructureConfigrations(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));
             //   , b => b.MigrationsAssembly("Cqrs_Mediator.Api"))) ;
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddScoped(typeof(IAsyncUnitOfWork), typeof(AsyncUnitOfWork));
            services.AddScoped(typeof(IRepositoryProduct), typeof(ProdcutRepository));
            services.AddScoped(typeof(IDbConnectionFactory<>), typeof(DbConnectionFactory<>));

            return services;
        }
    }
}
