using GestionTareas.Application.Interfaces;
using GestionTareas.Infrastructure.Persistence;

namespace GestionTareas.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITareaRepository, TareaRepository>();
            return services;
        }
    }
}
