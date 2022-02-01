using Battleship.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Battleship.Application.Interfaces
{
    public interface IBoardRepository : IGenericRepository<Board>
    {
        Task<IEnumerable<Board>> FindBordsInGame(long gameId);
        Task<Board> GetBoardWithContent(long boardId, int x, int y);
        Task<bool> IsStrikeIsTheLastOnBattleship(long boardId, ICollection<Field> battshipArea);

    }
}
