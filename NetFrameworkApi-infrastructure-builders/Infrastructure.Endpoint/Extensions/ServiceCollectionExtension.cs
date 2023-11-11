using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Infrastructure.Endpoint.Builders;
using Infrastructure.Endpoint.Data;
using Infrastructure.Endpoint.Data.Repositories;
using Infrastructure.Endpoint.Interfaces;
using Infrastructure.Endpoint.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Endpoint.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IToDosRepository, ToDosRepository>();
            services.AddScoped<ISqlCommandOperationBuilder, SqlCommandOperationBuilder>();
            services.AddSingleton<IEntitiesService, EntitiesService>();
            services.AddSingleton<ISqlDbConnection>(SqlDbConnection.GetInstance());
            return services;
        }
    }
}
