using Battleship.Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Battleship.Application.Queries.Battleship
{
    public class GetAllBattleshipsQuery : IRequest<ICollection<BattleshipDto>>
    {
    }
}
