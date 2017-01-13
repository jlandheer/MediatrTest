using MediatR;

namespace ConsoleApp.Infrastructure
{
    public interface IQuery<out TResult> //: IRequest<TResult>
    {
    }
}