using Application.Common.CQRS;
using AutoMapper;
using Battleship.Application.Dtos;
using Battleship.Application.Interfaces;
using Battleship.Application.Queries.Battleship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Application.QueryHandlers.Battleship
{
    public class GetAllBattleshipsQueryHandler : CommandHandler<GetAllBattleshipsQuery, IBattleshipRepository, ICollection<BattleshipDto>>
    {
        public GetAllBattleshipsQueryHandler(IBattleshipRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override Task<ICollection<BattleshipDto>> Handle(GetAllBattleshipsQuery command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
