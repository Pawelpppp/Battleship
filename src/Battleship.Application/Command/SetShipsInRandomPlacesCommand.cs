using MediatR;

namespace Battleship.Application.Command
{
    public class SetShipsInRandomPlacesCommand : IRequest<long>
    {
        public long BoardId { get; set; }

        public SetShipsInRandomPlacesCommand(long id)
        {
            BoardId = id;
        }
    }
}
