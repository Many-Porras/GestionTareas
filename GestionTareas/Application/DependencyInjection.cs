using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using GestionTareas.Application.Interfaces;
using GestionTareas.Application.Services;
using GestionTareas.Application.Validators;

namespace GestionTareas.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Registra todos los validadores contenidos en el ensamblado de la aplicación
            services.AddValidatorsFromAssembly(typeof(CreateTareaValidator).Assembly);

            services.AddScoped<ITareaService, TareaService>();
            return services;
        }
    }
}
