using Battleship.Application.Command.Battleship;
using MediatR;

namespace Battleship.Application.Command.Board
{
    public class ShotBoardCommand : IRequest<ShotResponse>
    {
        public long BoardId { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }

        public ShotBoardCommand(long boardId, int? x, int? y)
        {
            BoardId = boardId;
            X = x;
            Y = y;
        }
    }
}
