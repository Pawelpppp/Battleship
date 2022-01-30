using Application.Common.CQRS;
using AutoMapper;
using Battleship.Application.Command.Battleship;
using Battleship.Application.Common.Exceptions;
using Battleship.Application.Dtos;
using Battleship.Application.Interfaces;
using Battleship.Domain.Entities;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Application.CommandHandler.Battleship
{
    public class SetShipCommandHandler : CommandHandler<SetShipCommand, IBattleshipRepository, bool>
    {
        private readonly IBoardRepository _boardRepository;
        public SetShipCommandHandler(IBattleshipRepository repository, IBoardRepository boardRepository, IMapper mapper) : base(repository, mapper)
        {
            _boardRepository = boardRepository;
        }

        public override async Task<bool> Handle(SetShipCommand command, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.FindAsync(command.BoradId);
            if (board == null)
            {
                throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("BoradId", $"Board with Id:{command.BoradId} does not exists") });
            }

            return false;
        }        
    }
}
