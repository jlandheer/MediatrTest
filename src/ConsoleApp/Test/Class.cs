//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ConsoleApp.Test
//{
//    public interface ILegacyRequest<TResult>
//    {
//    }

//    public interface IRequest<TValue> : ILegacyRequest<>
//    {
//    }

//    public sealed class Result<TValue>
//    {
//        public TValue Value { get; set; }
//        public string[] Errors { get; set; }
//    }

//    public interface IHandler<TRequest, TValue> where TRequest : IRequest<TValue>
//    {
//        Result<TValue> Handle(TRequest request);
//    }

//    public class TestRequest : IRequest<TestValue>
//    {
//    }

//    public class TestValue
//    {
//    }
//}
