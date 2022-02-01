using Application.Common.CQRS;
using AutoMapper;
using Battleship.Application.Command.Battleship;
using Battleship.Application.Command.Board;
using Battleship.Application.Common.Exceptions;
using Battleship.Application.Interfaces;
using Battleship.Domain.Entities;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Application.CommandHandler.Board
{
    internal class ShotBoardCommandHandler : CommandHandler<ShotBoardCommand, IBoardRepository, ShotResponse>
    {
        public readonly IMediator _mediator;
        public ShotBoardCommandHandler(IBoardRepository repository, IMapper mapper, IMediator mediator) : base(repository, mapper)
        {
            _mediator = mediator;
        }

        public override async Task<ShotResponse> Handle(ShotBoardCommand command, CancellationToken cancellationToken)
        {
            var board = await _repository.GetBoardWithContent(command.BoardId, command.X.Value, command.Y.Value);

            var field = new Field(command.X.Value, command.Y.Value);
            var isShotRepeated = board.Shots.Any(x => x.X == field.X && x.Y == field.Y);
            if (isShotRepeated)
            {
                throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("Borad.Shots", $"Shot at target X:{field.X} and Y:{field.Y} is was fired") });
            }

            ShotResponse response;
            var battleshipHited = board.Battleships.Where(b => b.Area.Any(x => x.X == field.X && x.Y == field.Y)).FirstOrDefault();
            if (battleshipHited != null)
            {
                response = await _mediator.Send(new ShotBattleshipCommand(battleshipHited.Id, command.X, command.Y));
            }
            else
            {
                response = new ShotResponse("You miss the ship. Now move another user");
            }

            // Add shot
            board.Shots.Add(field);
            await _repository.UpdateAsync(board, false);

            return response;
        }
    }
}
