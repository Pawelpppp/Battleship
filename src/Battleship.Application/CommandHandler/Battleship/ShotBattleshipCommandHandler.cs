using Application.Common.CQRS;
using AutoMapper;
using Battleship.Application.Command.Battleship;
using Battleship.Application.Common.Exceptions;
using Battleship.Application.Interfaces;
using Battleship.Domain.Entities;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Application.CommandHandler.Ship
{
    public class ShotBattleshipCommandHandler : CommandHandler<ShotBattleshipCommand, IBattleshipRepository, ShotResponse>
    {
        private readonly IBoardRepository _boardRepository;

        public ShotBattleshipCommandHandler(IBattleshipRepository repository, IBoardRepository boardRepository, IMapper mapper) : base(repository, mapper)
        {
            _boardRepository = boardRepository;
        }

        public override async Task<ShotResponse> Handle(ShotBattleshipCommand command, CancellationToken cancellationToken)
        {
            var battleship = await _repository.FindAsync(command.BattleshipId);
            if (battleship == null)
            {
                throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("Battleship", $"Battleship with Id:{command.BattleshipId} does not exists") });
            }

            var filed = new Field(command.X.Value, command.Y.Value);
            //validate that target was hited
            if (!battleship.Area.Any(x => x.X == filed.X && x.Y == filed.Y))
            {
                throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("Battleship", $"Battleship does not contain x:{filed.X} Y:{filed.Y}") });
            }

            //is ship destroyed ?
            var isStrikeIsLast = await _boardRepository.IsStrikeIsTheLastOnBattleship(battleship.BoardId, battleship.Area);
            if (isStrikeIsLast)
            {
                //return message that ship is destroyed
                battleship.IsDestroyed = true;
                await _repository.UpdateAsync(battleship, false);
                return new ShotResponse($"The Battleship {battleship.Name} was destroyed");
            }

            return new ShotResponse($"The Battleship {battleship.Name} was hited");
        }
    }
}
