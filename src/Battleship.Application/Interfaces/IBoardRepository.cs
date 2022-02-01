using System.Collections.Generic;
using System.Threading.Tasks;

namespace Battleship.Application.Interfaces
{
    public interface IBoardRepository : IGenericRepository<Battleship.Domain.Entities.Board>
    {
        Task<IEnumerable<Battleship.Domain.Entities.Board>> FindBordsInGame(long gameId);
    }
}
