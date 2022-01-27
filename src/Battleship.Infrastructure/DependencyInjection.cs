using Battleship.Application.Interfaces;
using Battleship.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Battleship.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {


            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseNpgsql(
            //        configuration.GetConnectionString("DefaultConnection"),
            //        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddTransient<IBattleshipRepository, BattleshipRepository>();
            return services;
        }
    }
}