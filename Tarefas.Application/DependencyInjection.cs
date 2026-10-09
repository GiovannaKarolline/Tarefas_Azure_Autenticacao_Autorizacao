using Microsoft.Extensions.DependencyInjection;
using Tarefas.Application.Services;

namespace Tarefas.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<TarefaService>();

            return services;
        }
    }
}
