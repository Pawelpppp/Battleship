using MediatR;

namespace Battleship.Application.Command.Game
{
    public class ShotCommand : IRequest<long>
    {
        public long GameId { get; set; }
        public long? X { get; set; }
        public long? Y { get; set; }
    }
}
