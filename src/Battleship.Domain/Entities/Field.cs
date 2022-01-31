using Battleship.Domain.Enums;

namespace Battleship.Domain.Entities
{
    public class Field : EntityBase
    {
        public Field()
        {

        }

        public Field(int x, int y)
        {
            X = (XAxis)x;
            Y = (YAxis)y;
        }

        public XAxis X { get; set; }
        public YAxis Y { get; set; }
    }

}
