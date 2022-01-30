using Battleship.Application.Dtos;
using MediatR;

namespace Battleship.Application.Command.Battleship
{
    public class SetShipCommand : IRequest<bool>
    {
        public long BoradId { get; set; }
        public BattleshipTypeDto ShipType { get; set; }
        public bool IsVertical { get; set; }
        public int StartPointX { get; set; }
        public int StartPointY { get; set; }
    }
}
