using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.Infrastructure
{
    public class CommandResult
    {
        public IEnumerable<string> Errors { get; }
        public bool IsValid { get; }

        private CommandResult()
        {
            Errors = new ReadOnlyCollection<string>(new List<string>());
            IsValid = true;

        }

        private CommandResult(IEnumerable<string> errors)
        {
            Errors = new ReadOnlyCollection<string>((errors ?? new List<string>()).ToList());
            IsValid = Errors.Any();
        }

        public static Task<CommandResult> SuccesTask = Task.FromResult(new CommandResult());

        public static Task<CommandResult> FailedTask(IEnumerable<string> errors) => Task.FromResult(new CommandResult(errors));
    }
}