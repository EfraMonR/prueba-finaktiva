using Backend.Application.Contracts.Infraestructure;
using Backend.Infraestructure.API;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infraestructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection AddInfraestructuraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IApiService<>), typeof(ApiService<>));
            services.AddScoped(typeof(IServiceEventLog<>), typeof(ServiceEventLog<>));
            return services;
        }
    }
}
