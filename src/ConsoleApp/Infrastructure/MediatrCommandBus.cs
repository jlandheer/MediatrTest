using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ConsoleApp.Infrastructure
{
    public class MediatorCommandBus : ICommandBus, IQueryBus
    {
        private readonly IMediator _mediator;

        public MediatorCommandBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<CommandResult> Send(ICommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            return _mediator.Send(command, cancellationToken);
        }

        public QueryResult<TResult> Get<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = new CancellationToken()) where TQuery : IQuery<TResult>
        {
            //return _mediator.Send(query, cancellationToken);
            return (QueryResult<TResult>)null;
        }
    }
}