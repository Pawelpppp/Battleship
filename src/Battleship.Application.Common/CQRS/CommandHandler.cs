using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Battleship.Application.Common.Interfaces;

namespace Application.Common.CQRS
{
    public abstract class CommandHandler<TCommand, TRepository> : IRequestHandler<TCommand>
        where TCommand : IRequest
        where TRepository : IGenericRepositoryBase
    {
        protected readonly TRepository _repository;

        public CommandHandler(TRepository repository)
        {
            _repository = repository;
        }

        public abstract Task<Unit> Handle(TCommand command, CancellationToken cancellationToken);
    }

    public abstract class CommandHandler<TCommand, TRepository, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : IRequest<TResponse>
        where TRepository : IGenericRepositoryBase
    {
        protected readonly TRepository _repository;
        protected readonly IMapper _mapper;

        public CommandHandler(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
