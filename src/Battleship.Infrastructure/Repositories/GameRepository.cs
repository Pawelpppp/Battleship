using Battleship.Application.Interfaces;
using Battleship.Domain.Entities;
using Battleship.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Battleship.Infrastructure.Repositories
{
    internal class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Game GetGame(long gameId)
        {
            var result = Get().Where(e => e.Id == gameId).Include(x => x.Boards).Single();
            return result;
        }
    }
}
