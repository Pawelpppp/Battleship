using Application.Common.CQRS;
using AutoMapper;
using Battleship.Application.Command.Battleship;
using Battleship.Application.Command.Game;
using Battleship.Application.Common.Exceptions;
using Battleship.Application.Interfaces;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Application.CommandHandler.Game
{
    public class GameRandomShipCommandHandler : CommandHandler<GameRandomShipCommand, IGameRepository, long>
    {
        private readonly IBoardRepository _boardRepository;
        public readonly IMediator _mediator;
        public GameRandomShipCommandHandler(IGameRepository repository, IBoardRepository boardRepository, IMediator mediator, IMapper mapper) : base(repository, mapper)
        {
            _boardRepository = boardRepository;
            _mediator = mediator;
        }

        public override async Task<long> Handle(GameRandomShipCommand command, CancellationToken cancellationToken)
        {
            var game = await _repository.FindAsync(command.GameId);
            if (game == null)
            {
                throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("GameId", $"Game with Id:{command.GameId} does not exists") });
            }

            var boards = await _boardRepository.FindBordsInGame(game.Id);
            // (papa)todo: validate we have exactly two board connected to Game

            await _mediator.Send(new SetShipsInRandomPlacesCommand(boards.First().Id));
            await _mediator.Send(new SetShipsInRandomPlacesCommand(boards.ElementAt(1).Id));

            return game.Id;
        }
    }
}
