using System.Collections.Generic;

namespace Battleship.Application.Interfaces
{
    public interface IBattleshipRepository : IGenericRepository<Battleship.Domain.Entities.Battleship>
    {
        IEnumerable<Battleship.Domain.Entities.Battleship> GetAllShipsFromBord(long id);
    }

}
