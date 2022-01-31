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

namespace Battleship.Application.CommandHandler.Ship
{
    public class SetShipCommandHandler : CommandHandler<SetShipCommand, IBattleshipRepository, long>
    {
        private readonly IBoardRepository _boardRepository;
        public SetShipCommandHandler(IBattleshipRepository repository, IBoardRepository boardRepository, IMapper mapper) : base(repository, mapper)
        {
            _boardRepository = boardRepository;
        }

        public override async Task<long> Handle(SetShipCommand command, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.FindAsync(command.BoradId);
            if (board == null)
            {
                throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("BoradId", $"Board with Id:{command.BoradId} does not exists") });
            }

            var battelships = _repository.GetAllShipsFromBord(board.Id);
            var battleShipArea = GenerateShipArea(command.StartPointX, command.StartPointY, command.IsVertical, command.ShipType);

            var areaInUse = battelships?.SelectMany(x => x.Area).ToList();
            if (!IsAreaIsEmptyToPutShip(areaInUse, battleShipArea))
            {
                throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("Battleship.Area", $"Battleship area is in use") });
            }

            if (IsTypeOfShipIsOnBord(battelships, command.ShipType))
            {
                throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("Battleship.Type", $"Battleship of type {command.ShipType} is allready set in the board") });
            }

            var newBattleship = new Domain.Entities.Battleship(battleShipArea, command.ShipType.ToString(), board);
            await _repository.InsertAsync(newBattleship);

            return newBattleship.Id;
        }

        private bool IsTypeOfShipIsOnBord(IEnumerable<Domain.Entities.Battleship> battelships, BattleshipTypeDto shipType)
        {
           var result= battelships.Any(x => x.Name == shipType.ToString());
            return result;
        }

        /// <summary>
        /// Validate that area where we put ships are free
        /// </summary>
        /// <param name="areaInUse"></param>
        /// <param name="battleShipArea"></param>
        /// <returns></returns>
        private bool IsAreaIsEmptyToPutShip(IEnumerable<Field> areaInUse, IEnumerable<Field> battleShipArea)
        {
            if (areaInUse != null)
            {
                var common = areaInUse?.FirstOrDefault(x => battleShipArea.Any(y => y.X == x.X || y.Y == x.Y));

                if (common != null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Validate that correct ship type is not set
        /// </summary>
        /// <param name="startPointX"></param>
        /// <param name="startPointY"></param>
        /// <param name="isVertical"></param>
        /// <param name="shipType"></param>
        /// <returns></returns>
        private List<Field> GenerateShipArea(int startPointX, int startPointY, bool isVertical, BattleshipTypeDto shipType)
        {
            var size = (int)shipType;
            var result = new List<Field>();
            for (int i = 0; i < size; i++)
            {
                var x = isVertical ? startPointX : startPointX + i;
                var y = isVertical ? startPointY + i : startPointY;
                result.Add(new Field(x, y));
            }
            return result;
        }
    }
}
