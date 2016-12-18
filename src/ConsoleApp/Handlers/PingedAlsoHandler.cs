using ConsoleApp.Commands;
using MediatR;

namespace ConsoleApp.Handlers
{
    public class PingedAlsoHandler : INotificationHandler<Pinged>
    {
        public void Handle(Pinged notification)
        {
            System.Console.WriteLine("PingedAlsoHandler");
        }
    }
}