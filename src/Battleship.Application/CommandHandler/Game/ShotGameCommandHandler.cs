using Application.Common.CQRS;
using AutoMapper;
using Battleship.Application.Command.Battleship;
using Battleship.Application.Command.Board;
using Battleship.Application.Command.Game;
using Battleship.Application.Common.Exceptions;
using Battleship.Application.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Application.CommandHandler.Game
{
    public class ShotGameCommandHandler : CommandHandler<ShotGameCommand, IGameRepository, ShotResponse>
    {
        private readonly IMediator _mediator;

        public ShotGameCommandHandler(IGameRepository repository, IMediator mediator, IMapper mapper) : base(repository, mapper)
        {
            _mediator = mediator;
        }

        public override async Task<ShotResponse> Handle(ShotGameCommand command, CancellationToken cancellationToken)
        {
            SetRandomValues(ref command);

            var game = _repository.WithContend(command.GameId);
            if (game == null)
            {
                throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("Game", $"Game with Id:{game.Id} does not exists") });
            }
            long boardId = game.IsBoardAMove ? game.Boards.First().Id : game.Boards.ElementAt(1).Id;
            if (game.Boards.Any(x => x.IsBattleshipsDestyroyed))
            {
                return new ShotResponse($"Game Over! One of the players Won!. Please start new Game");
            }

            var response = await _mediator.Send(new ShotBoardCommand(boardId, command.X, command.Y));
            game.IsBoardAMove = !game.IsBoardAMove;
            await _repository.UpdateAsync(game);

            return response;
        }

        // to beter test ranom target
        private void SetRandomValues(ref ShotGameCommand command)
        {
            var rand = new Random();
            command.GameId = command.GameId != 0 ? command.GameId : 3;
            command.X = command.X != 0 ? command.X : rand.Next(1, 10);
            command.Y = command.Y != 0 ? command.Y : rand.Next(1, 10);
        }
    }
}
