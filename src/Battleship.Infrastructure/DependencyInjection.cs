using Battleship.Application.Common.Interfaces;
using Battleship.Application.Interfaces;
using Battleship.Infrastructure.Persistence;
using Battleship.Infrastructure.Repositories;
using Battleship.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Battleship.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddTransient<IDateTime, DateTimeService>();

            services.AddTransient<IBattleshipRepository, BattleshipRepository>();
            services.AddTransient<IBoardRepository, BoardRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            return services;
        }
    }
}