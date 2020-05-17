using Fiber.Contracts;
using Fiber.Interfaces;
using Fiber.Operations;
using Microsoft.Extensions.Logging;
using System;
using Xunit;


namespace FiberTests
{
    public class OperationTests
    {
        /*
        internal class OperationTest<T, U, V> : Operation<T, U, V>
        {
            public OperationTest(ILogger logger, IOperationProtocol<T, U> protocol) : base(logger, protocol)
            {
            }
        }

        [Fact]
        public void HasMethodCallAndRaisesNotImplementedException()
        {
            var logger = new object() as ILogger;
            var protocol = new object() as IProtocol;
            var request = new object() as IRequest;

            IOperationAction operationRequest = new OperationRequest(request);
            IOperation operation = new OperationTest(logger, protocol);

            Assert.Throws<NotImplementedException>( () => operation.Call(operationRequest) );
        }
        
        [Fact]
        public void HasMethodPrepareAndRaisesNotImplementedException()
        {
            var logger = new object() as ILogger;
            var protocol = new object() as IProtocol;
            var request = new object() as IRequest;

            IOperationAction operationRequest = new OperationRequest(request);
            IOperation operation = new OperationTest(logger, protocol);

            Assert.Throws<NotImplementedException>(() => operation.Prepare(operationRequest) );
        }
    */
    }
}
