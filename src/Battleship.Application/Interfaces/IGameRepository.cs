using Battleship.Domain.Entities;
using System.Collections.Generic;

namespace Battleship.Application.Interfaces
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        public Game GetGame(long gameId);
    }
}
