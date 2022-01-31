using Battleship.Domain.Enums;
using System.Collections.Generic;

namespace Battleship.Domain.Entities
{
    public class Battleship : EntityBase
    {
        public Battleship()
        {

        }

        public Battleship(ICollection<Field> area, BattleshipType type, Board board)
        {
            Area = area;
            Name = type.ToString();
            Type = type;
            Board = board;
            BoardId = board.Id;
        }

        public string Name { get; set; }

        public BattleshipType Type { get; set; }
        public bool IsDestroyed { get; set; }

        // relations
        public Board Board { get; set; }
        public long BoardId { get; set; }

        public ICollection<Field> Area { get; set; }
    }
}
