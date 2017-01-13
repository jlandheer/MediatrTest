using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Infrastructure
{
    public interface IQueryBus
    {
        /// <summary>
        /// Asynchronously send a Query to a single handler
        /// </summary>
        /// <param name="query">Query object</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A task that represents the send operation. The task result contains the handler response</returns>
        Task<TResult> Get<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default(CancellationToken));
    }
}