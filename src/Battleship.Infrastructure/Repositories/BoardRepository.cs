using Battleship.Application.Interfaces;
using Battleship.Domain.Entities;
using Battleship.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Infrastructure.Repositories
{
    internal class BoardRepository : GenericRepository<Board>, IBoardRepository
    {
        public BoardRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Board>> FindBordsInGame(long gameId)
        {
            var response = Get().Where(x => x.GameOwnerId == gameId).AsEnumerable();
            return Task.FromResult(response);
        }
    }
}
