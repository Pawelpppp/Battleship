using Battleship.Application.Command.Battleship;
using MediatR;
using System;

namespace Battleship.Application.Command.Game
{
    public class ShotGameCommand : IRequest<ShotResponse>
    {
        public long GameId { get; set; } = 1;
        public int? X { get; set; } = 5;
        public int? Y { get; set; } = 1;
    }
}
