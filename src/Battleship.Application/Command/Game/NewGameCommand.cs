using MediatR;

namespace Battleship.Application.Command.Game
{
    public class NewGameCommand : IRequest<long>
    {
        public long? BoardA { get; set; }
        public long? BoardB { get; set; }
    }
}
