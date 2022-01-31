using System.Collections.Generic;

namespace Battleship.Domain.Entities
{
    public class Battleship : EntityBase
    {

        public Battleship()
        {

        }

        public Battleship(ICollection<Field> area, string name, Board board)
        {
            Area = area;
            Name = name;
            Board = board;
            BoardId = board.Id;
        }

        public string Name { get; set; }

        public bool IsDestroyed { get; set; }

        public Board Board { get; set; }
        public long BoardId { get; set; }

        public ICollection<Field> Area { get; set; }
    }
}
