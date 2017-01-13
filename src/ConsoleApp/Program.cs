using MediatR;
using System;
using System.Reflection;
using ConsoleApp.Commands;
using ConsoleApp.Decorators;
using FluentValidation;
using SimpleInjector;
using ConsoleApp.Infrastructure;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var assemblies = new[] { Assembly.GetExecutingAssembly() };
            var commandQueryContainer = new Container();

            var mediator = new Mediator(commandQueryContainer.GetInstance, commandQueryContainer.GetAllInstances);

            var mediatorCommandQueryBus = new MediatorCommandBus(mediator);
            commandQueryContainer.Register<ICommandBus>(() => mediatorCommandQueryBus, Lifestyle.Singleton);
            commandQueryContainer.Register<IQueryBus>(() => mediatorCommandQueryBus, Lifestyle.Singleton);

            commandQueryContainer.Register(typeof(IAsyncRequestHandler<,>), assemblies);
            commandQueryContainer.Register(typeof(ICancellableAsyncRequestHandler<>), assemblies);
            commandQueryContainer.RegisterCollection(typeof(IValidator<>), assemblies);
            commandQueryContainer.RegisterCollection(typeof(IPipelineBehavior<,>), assemblies);

            commandQueryContainer.RegisterDecorator(typeof(IAsyncRequestHandler<,>), typeof(ValidationDecorator<>));
            commandQueryContainer.RegisterDecorator(typeof(IAsyncRequestHandler<,>), typeof(AuthorizationDecorator<>));

            // Voor de commandContainer worden geen Notificatie (Event) Handlers geregistreerd,
            // Dat moet via de eventContainer.
            commandQueryContainer.RegisterCollection(typeof(INotificationHandler<>));
            commandQueryContainer.RegisterCollection(typeof(IAsyncNotificationHandler<>));
            commandQueryContainer.RegisterCollection(typeof(ICancellableAsyncNotificationHandler<>));

            var commandBus = commandQueryContainer.GetInstance<ICommandBus>();
            var queryBus = commandQueryContainer.GetInstance<IQueryBus>();

            while (true)
            {
                Console.WriteLine("Type message:");
                var message = Console.ReadLine();
                if (message == "q")
                    break;

                var res = commandBus.Send(new TestCommand { Message = message }).Result;
                Console.WriteLine($"Command : {res.IsValid}");
                var query = queryBus.Get(new TestQuery { Message = message });
                Console.WriteLine($"Command : {res.IsValid}");
            }
            Console.WriteLine("bye...");
            Console.ReadKey();
        }
    }

    public class TestQuery : IQuery<TestQueryResult>
    {
        public string Message { get; set; }
    }

    public class TestQueryResult
    {
    }
}
