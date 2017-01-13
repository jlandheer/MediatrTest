using System;
using SimpleInjector;

namespace ConsoleApp.Extensions
{
    public static class SimpleInjectorExtensions
    {
        public static void UnRegisteredType(this Container container, Type unregisteredType, Type defaultImplementationType)
        {
            container.ResolveUnregisteredType += (sender, e) =>
            {
                if (e.UnregisteredServiceType.IsGenericType &&
                    e.UnregisteredServiceType.GetGenericTypeDefinition() == unregisteredType)
                {
                    var validatorType = defaultImplementationType.MakeGenericType(e.UnregisteredServiceType.GetGenericArguments());

                    var emptyValidator = container.GetInstance(validatorType);

                    // Register the instance as singleton.
                    e.Register(() => emptyValidator);
                }
            };
        }
    }
}
