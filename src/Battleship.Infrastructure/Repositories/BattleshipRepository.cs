using Battleship.Application.Interfaces;
using Battleship.Infrastructure.Persistence;

namespace Battleship.Infrastructure.Repositories
{
    internal class BattleshipRepository : GenericRepository<Battleship.Domain.Entities.Battleship>, IBattleshipRepository
    {
        public BattleshipRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
