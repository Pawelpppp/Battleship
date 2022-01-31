using Battleship.Application.Interfaces;
using Battleship.Domain.Entities;
using Battleship.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Infrastructure.Repositories
{
    internal class BattleshipRepository : GenericRepository<Battleship.Domain.Entities.Battleship>, IBattleshipRepository
    {
        public BattleshipRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Battleship.Domain.Entities.Battleship> GetAllShipsFromBord(long id)
        {
            var result = Get().Where(x => x.BoardId == id).AsEnumerable();
            return result;
        }
    }
}
