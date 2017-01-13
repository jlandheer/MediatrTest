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

        public Task Send(ICommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            return _mediator.Send(command, cancellationToken);
        }

        public Task<TResult> Get<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = new CancellationToken())
        {
            return _mediator.Send(query, cancellationToken);
        }
    }
}