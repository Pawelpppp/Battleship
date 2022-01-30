using System.Collections.Generic;

namespace Battleship.Domain.Entities
{
    public class Game : EntityBase
    {
        public ICollection<Board> Boards { get; set; }
    }
}
