using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Infrastructure
{
    public class CommandResult
    {
        public IEnumerable<string> Errors { get; }
        public bool IsValid => !(Errors?.Any() ?? false);

        public CommandResult()
        {
        }

        public CommandResult(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}