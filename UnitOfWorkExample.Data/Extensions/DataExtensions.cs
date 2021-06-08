using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkExample.Data.Context;
using UnitOfWorkExample.Data.Repositories;

namespace UnitOfWorkExample.Data.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EventoContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("EventoDb"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            return services;
        }
    }
}
