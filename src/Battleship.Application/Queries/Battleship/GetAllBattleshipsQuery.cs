using Battleship.Application.Dtos;
using MediatR;

namespace Battleship.Application.Queries.Battleship
{
    public class GetAllBattleshipsQuery : IRequest<BattleshipDto>
    {
        public long id;
    }
}
