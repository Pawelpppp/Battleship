using Application.Common.CQRS;
using AutoMapper;
using Battleship.Application.Dtos;
using Battleship.Application.Interfaces;
using Battleship.Application.Queries.Battleship;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Application.QueryHandlers.Battleship
{
    public class GetAllBattleshipsQueryHandler : CommandHandler<GetAllBattleshipsQuery, IBattleshipRepository, BattleshipDto>
    {
        private readonly IBattleshipRepository _repository;
        private readonly IMapper _mapper;

        public GetAllBattleshipsQueryHandler(IBattleshipRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<BattleshipDto> Handle(GetAllBattleshipsQuery reqest, CancellationToken cancellationToken)
        {
            var battleship = await _repository.FindAsync(reqest.id);
            return _mapper.Map<BattleshipDto>(battleship);
        }
    }
}
