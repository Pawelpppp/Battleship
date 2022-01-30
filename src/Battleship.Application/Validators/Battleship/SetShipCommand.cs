﻿using Battleship.Application.Command.Battleship;
using Battleship.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Application.Validators.Battleship
{
    public class SetShipCommandValidator : AbstractValidator<SetShipCommand>
    {
        private const int boardSize = 10;
        public SetShipCommandValidator()
        {
            RuleFor(x => x.BoradId)
                .NotEmpty();
            RuleFor(x => x.ShipType)
                .NotEmpty()
                .NotEqual(BattleshipTypeDto.Empty)
                .IsInEnum();
            RuleFor(x => x.StartPointX)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .LessThan(boardSize);
            RuleFor(x => x.StartPointY)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(boardSize);
            RuleFor(x => x).Must(ShipMastHaveSpace)
                .WithMessage("Not enoth space for ship");
        }

        private bool ShipMastHaveSpace(SetShipCommand command)
        {
            if (command.IsVertical)
            {
                return (command.StartPointX + (int)command.ShipType) < boardSize;
            }
            else
            {
                return (command.StartPointY + (int)command.ShipType) < boardSize;
            }
        }
    }
}
