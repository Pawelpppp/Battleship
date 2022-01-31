using Application.Common.CQRS;
using AutoMapper;
using Battleship.Application.Command.Game;
using Battleship.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Application.CommandHandler.Game
{
    public class NewGameCommandHandler : CommandHandler<NewGameCommand, IGameRepository, long>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IMediator _mediator;

        public NewGameCommandHandler(IGameRepository repository, IBoardRepository boardRepository, IMediator mediator, IMapper mapper) : base(repository, mapper)
        {
            _boardRepository = boardRepository;
            _mediator = mediator;
        }

        public override async Task<long> Handle(NewGameCommand command, CancellationToken cancellationToken)
        {
            var boardA = await GetOrAdd(command.BoardA);
            var boardB = await GetOrAdd(command.BoardB);

            var newGame = new Battleship.Domain.Entities.Game();
            newGame.Boards = new List<Domain.Entities.Board>() { boardA, boardB };

            await _repository.InsertAsync(newGame);

            return newGame.Id;
        }

        private async Task<Domain.Entities.Board> GetOrAdd(long? id)
        {
            Domain.Entities.Board board = null;
            if (id.HasValue)
            {
                board = await _boardRepository.FindAsync(id.Value);
                if (board != null)
                {
                    return board;
                }
            }

            board = new Domain.Entities.Board();
            await _boardRepository.InsertAsync(board);
            return board;
        }
    }
}
