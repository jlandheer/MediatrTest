using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Infrastructure
{
    public interface IQueryBus
    {
        QueryResult<TResult> Get<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default(CancellationToken))
            where TQuery : IQuery<TResult>;
    }
}