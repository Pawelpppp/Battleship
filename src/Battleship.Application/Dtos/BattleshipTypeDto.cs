using Battleship.Application.Attributes;

namespace Battleship.Application.Dtos
{
    public enum BattleshipTypeDto
    {
        Empty = 0,

        [ShipSize(2)]
        PatrolBoat = 1,

        [ShipSize(3)]
        Submarine = 2,

        [ShipSize(3)]
        Destroyer = 3,

        [ShipSize(4)]
        Battleship = 4,

        [ShipSize(5)]
        Carrier = 5,
    }
}
