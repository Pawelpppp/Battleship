using MediatR;

namespace Battleship.Application.Command.Battleship
{
    public class ShotBattleshipCommand : IRequest<ShotResponse>
    {
        public long BattleshipId { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }

        public ShotBattleshipCommand(long id, int? x, int? y)
        {
            BattleshipId = id;
            X = x;
            Y = y;
        }
    }
}
