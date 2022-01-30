using Battleship.Domain.Enums;

namespace Battleship.Domain.Entities
{
    public class Field : EntityBase
    {
        public XAxis X { get; set; } 
        public YAxis Y { get; set; } 
    }

}
