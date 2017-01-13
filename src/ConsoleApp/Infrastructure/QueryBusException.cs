using System;

namespace ConsoleApp.Infrastructure
{
    public abstract class QueryBusException : Exception
    {
        protected QueryBusException() { }
        protected QueryBusException(string message) : base(message) { }
    }
}