using System.Threading.Tasks;
using ConsoleApp.Commands;
using MediatR;

namespace ConsoleApp.Handlers
{
    public class PingedAsyncHandler : IAsyncNotificationHandler<PingedAsync>
    {
        public Task Handle(PingedAsync notification)
        {
            System.Console.WriteLine("PingedAsyncHandler");
            return Task.CompletedTask;
        }
    }
}