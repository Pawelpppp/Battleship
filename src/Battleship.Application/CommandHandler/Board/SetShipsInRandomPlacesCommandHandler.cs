using Application.Common.CQRS;
using AutoMapper;
using Battleship.Application.Attributes;
using Battleship.Application.Command;
using Battleship.Application.Command.Battleship;
using Battleship.Application.Common.Exceptions;
using Battleship.Application.Common.Extensions;
using Battleship.Application.Dtos;
using Battleship.Application.Interfaces;
using Battleship.Domain.Enums;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Application.CommandHandler.Board
{
    public class SetShipsInRandomPlacesCommandHandler : CommandHandler<SetShipsInRandomPlacesCommand, IBoardRepository, long>
    {
        private const int attemptMax = 10;
        private readonly List<BattleshipType> _avalibleShips;
        private readonly IBattleshipRepository _battleshipRepository;
        private readonly IMediator _mediator;
        private readonly Random _rand;

        public SetShipsInRandomPlacesCommandHandler(IBoardRepository repository, IBattleshipRepository battleshipRepository, IMediator mediator, IMapper mapper) : base(repository, mapper)
        {
            _battleshipRepository = battleshipRepository;
            _mediator = mediator;
            _avalibleShips = new()
            {
                BattleshipType.Carrier,
                BattleshipType.Battleship,
                BattleshipType.Destroyer,
                BattleshipType.Submarine,
                BattleshipType.PatrolBoat,
            };
            _rand = new Random();
        }

        public override async Task<long> Handle(SetShipsInRandomPlacesCommand command, CancellationToken cancellationToken)
        {
            var board = await _repository.FindAsync(command.BoardId);
            if (board == null)
            {
                throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("BoradId", $"Board with Id:{command.BoardId} does not exists") });
            }

            var battelships = _battleshipRepository.GetAllShipsFromBord(board.Id);
            foreach (var posiibleShipType in _avalibleShips)
            {
                if (!battelships.Any(x => x.Type == posiibleShipType))
                {
                    var setShipCommand = GenerateRandomSetShipCommand(_mapper.Map<BattleshipTypeDto>(posiibleShipType), command.BoardId);
                    var result = await TrayAdd(0, setShipCommand);
                }
            }

            return board.Id;
        }

        /// <summary>
        /// Attempting to add a new ship to the board
        /// </summary>
        /// <param name="atteptNymber"></param>
        /// <param name="setShipCommand"></param>
        /// <returns></returns>
        private async Task<long?> TrayAdd(int atteptNymber, SetShipCommand setShipCommand)
        {
            long? result = null;
            if (atteptNymber > attemptMax)
            {
                return null;
            }
            try
            {
                result = await _mediator.Send(setShipCommand);
            }
            catch (ValidationException ex)
            {
                // log

                //chenge the values
                setShipCommand = GenerateRandomSetShipCommand(setShipCommand.ShipType, setShipCommand.BoradId);

                //try one more time
                await TrayAdd(atteptNymber++, setShipCommand);
            }

            return result;
        }

        private SetShipCommand GenerateRandomSetShipCommand(BattleshipTypeDto shipType, long boardId)
        {
            var attribute = shipType.GetAttribute<ShipSizeAttribute>();
            var size = (int)attribute?.Size;

            var result = new SetShipCommand();
            result.IsVertical = _rand.Next(2) == 0;
            result.StartPointX = result.IsVertical ? _rand.Next(10) : _rand.Next(10 - size);
            result.StartPointY = result.IsVertical ? _rand.Next(10 - size) : _rand.Next(10);
            result.ShipType = shipType;
            result.BoradId = boardId;

            return result;
        }
    }
}
