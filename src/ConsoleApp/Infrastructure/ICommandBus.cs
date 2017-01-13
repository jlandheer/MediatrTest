using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Infrastructure
{
    public interface ICommandBus
    {
        /// <summary>
        /// Asynchronously send a Command to a single handler
        /// </summary>
        /// <param name="command">Command object</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A task that represents the send operation. The task result contains the handler response</returns>
        Task<CommandResult> Send(ICommand command, CancellationToken cancellationToken = default(CancellationToken));
    }
}