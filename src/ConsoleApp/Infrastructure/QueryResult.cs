using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.Infrastructure
{
    public class QueryResult<TResult>
    {
        private static readonly Func<QueryResult<TResult>, TResult> SuccessResultValueAccess = i => i._result;
        private static readonly Func<QueryResult<TResult>, TResult> FailedResultValueAccess = i => { throw new CannotAccessFailedResultValue(); };

        public TResult Value => _resultAccess(this);
        public bool IsValid { get; } = true;
        public IEnumerable<string> Errors { get; } = new ReadOnlyCollection<string>(new List<string>());
        private readonly TResult _result;
        private readonly Func<QueryResult<TResult>, TResult> _resultAccess = SuccessResultValueAccess;

        private QueryResult(TResult result)
        {
            _result = result;
        }

        private QueryResult(IEnumerable<string> errors)
        {
            if (errors == null) throw new ArgumentNullException(nameof(errors));

            var errorList = errors as IList<string> ?? errors.ToList();

            if (!errorList.Any())
            {
                throw new CannotCreateFailedResultWithoutErrors();
            }

            Errors = new ReadOnlyCollection<string>(errorList.ToList());
            IsValid = false;
            _resultAccess = FailedResultValueAccess;
        }

        public static Task<QueryResult<TResult>> SuccesTask(TResult result) => Task.FromResult(new QueryResult<TResult>(result));

        public static Task<QueryResult<TResult>> FailedTask(IEnumerable<string> errors) => Task.FromResult(new QueryResult<TResult>(errors));
    }
}