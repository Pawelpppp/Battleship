using Application.Common.CQRS;
using AutoMapper;
using Battleship.Application.Command;
using Battleship.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Application.CommandHandler.Board
{
    internal class CreateBordCommandHandler : CommandHandler<CreateBordCommand, IBoardRepository, long>
    {
        public CreateBordCommandHandler(IBoardRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<long> Handle(CreateBordCommand command, CancellationToken cancellationToken)
        {
            var board = new Domain.Entities.Board();
            await _repository.InsertAsync(board);
            return board.Id;
        }
    }
}
