using System.Collections.Generic;

namespace ConsoleApp.Infrastructure
{
    public interface IQueryResult<TResult>
    {
        IEnumerable<string> Errors { get; }
        bool IsValid { get; }
        TResult Value { get; }
    }
}