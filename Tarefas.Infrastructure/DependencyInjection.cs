using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarefas.Application.Abstractions;
using Tarefas.Application.Abstractions.Tarefas;
using Tarefas.Infrastructure.Data.Persistence;
using Tarefas.Infrastructure.Data.Repositories;

namespace Tarefas.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<ITarefaRepository, TarefaRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}