using MediatR;
using System;
using System.Reflection;
using ConsoleApp.Commands;
using ConsoleApp.Decorators;
using FluentValidation;
using SimpleInjector;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var assemblies = new[] { Assembly.GetExecutingAssembly() };
            var container = new Container();

            container.Register<IMediator, Mediator>(Lifestyle.Singleton);
            container.RegisterSingleton(new SingleInstanceFactory(container.GetInstance));
            container.RegisterSingleton(new MultiInstanceFactory(container.GetAllInstances));

            container.RegisterCollection(typeof(IValidator<>), assemblies);
            container.Register(typeof(IRequestHandler<,>), assemblies);
            container.RegisterCollection(typeof(INotificationHandler<>), assemblies);
            container.RegisterDecorator(typeof(IRequestHandler<,>), typeof(ValidationDecorator<>));
            container.RegisterDecorator(typeof(IRequestHandler<,>), typeof(AuthorizationDecorator<>));

            var mediatr = container.GetInstance<IMediator>();

            while (true)
            {
                Console.WriteLine("Type message:");
                var message = Console.ReadLine();
                if (message == "q")
                    break;

                var res = mediatr.Send(new TestCommand2 { Message = message });
                Console.WriteLine($"Test : {res.IsValid}");
            }
            Console.WriteLine("bye...");
            Console.ReadKey();
        }
    }
}
