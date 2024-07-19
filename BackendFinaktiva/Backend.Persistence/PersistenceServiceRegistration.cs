using Backend.Application.Contracts.Persistence;
using Backend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Backend.Domain.Entities;
using Backend.Application.Contracts.Infraestructure;

namespace Backend.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<EventLogs>), typeof(BaseRepository<EventLogs>));
            return services;
        }
    }
}