using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpStorage.Application.Interfaces;
using SimpStorage.Infrastructure.Persistence;

namespace SimpStorage.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(opt =>
            {
                var connectionString = configuration.GetConnectionString("LocalSqliteDatabase");
                opt.UseSqlite(connectionString);
                opt.LogTo(Console.WriteLine);
            });

            services.AddScoped<IApplicationContext>(provider =>
            {
                var context = provider.GetService<ApplicationContext>()
                    ?? throw new NullReferenceException(nameof(ApplicationContext));
                context.Database.EnsureCreated();

                return context;
            });

            return services;
        }
    }
}
