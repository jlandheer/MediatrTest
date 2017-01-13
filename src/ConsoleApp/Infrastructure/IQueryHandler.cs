using System.Threading.Tasks;

namespace ConsoleApp.Infrastructure
{
    public interface IQueryHandler<in TRequest, TResult> /* : IAsyncRequestHandler<TRequest, TResult> */ where TRequest : IQuery<TResult>
    {
        Task<TResult> Handle(TRequest message);
    }
}
