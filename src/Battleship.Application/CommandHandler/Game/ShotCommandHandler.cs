using Application.Common.CQRS;
using AutoMapper;
using Battleship.Application.Command.Game;
using Battleship.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Application.CommandHandler.Game
{
    //ShotCommand
    public class ShotCommandHandler : CommandHandler<ShotCommand, IGameRepository, long>
    {
        public ShotCommandHandler(IGameRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override Task<long> Handle(ShotCommand command, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }

}
