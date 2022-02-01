using MediatR;

namespace Battleship.Application.Command.Game
{
    public class GameRandomShipCommand : IRequest<long>
    {
        public GameRandomShipCommand(long id)
        {
            GameId = id;
        }

        public long GameId { get; set; }
    }
}
