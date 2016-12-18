using System.Threading.Tasks;
using ConsoleApp.Commands;
using MediatR;

namespace ConsoleApp.Handlers
{
    public class PingedAlsoAsyncHandler : IAsyncNotificationHandler<PingedAsync>
    {
        public Task Handle(PingedAsync notification)
        {
            System.Console.WriteLine("PingedAlsoAsyncHandler");
            return Task.CompletedTask;
        }
    }
}

