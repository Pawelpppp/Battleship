using Battleship.Application.Interfaces;
using Battleship.Domain.Entities;
using Battleship.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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

        public Task<Board> GetBoardWithContent(long boardId, int x, int y)
        {
            var response = Get()
                .Where(x => x.Id == boardId)
                .Include(x => x.Shots)
                .Include(x => x.Battleships)
                .ThenInclude(shot => shot.Area).First();
            return Task.FromResult(response);
        }

        public Task<bool> IsStrikeIsTheLastOnBattleship(long boardId, ICollection<Field> battshipArea)
        {
            var shots = Get().Where(x => x.Id == boardId).SelectMany(x => x.Shots);
            var shipSttrikes = battshipArea.Select(x => shots.Any(y => y.X == x.X && y.Y == x.Y)).ToList();

            // check if this hit is the last area of battleship
            return Task.FromResult(shipSttrikes.Count(s => s == true) < shipSttrikes.Count);
        }

        public bool IsAllBattleshipDestroyed(long boardId)
        {
            var result = Get().Where(e => e.Id == boardId).All(x => x.IsBattleshipsDestyroyed);
            return result;
        }
    }
}
