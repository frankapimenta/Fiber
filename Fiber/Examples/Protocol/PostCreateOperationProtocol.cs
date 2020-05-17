using Fiber.Interfaces;
using Fiber.Interfaces.Operations;
using Fiber.Operations;
using Fiber.Protocols;
using Microsoft.Extensions.Logging;
using System;

namespace Fiber.Examples.Protocol
{
    public class PostCreateOperationProtocol<T, U, V> : OperationProtocol<T, U, V> where T : class, new() where U : class, new() where V : class, new()
    {
        public PostCreateOperationProtocol()  { }
        
        // can inject as many services as wanted
        public PostCreateOperationProtocol(/* ICoreApiClient client, */ ILogger logger, IOperationAction<T, U, V> action) : base(logger, action)
        {

        }

        public override IOperationAction<T, U, V> Call(Operation<T,U,V> operation)
        {
            logger.LogDebug("begin executing Call");

            Prepare(action);
            
            Enrich(action.OperationRequest());
            // ....
            Strip(action.OperationResponse());

            logger.LogDebug("end executing Call");
            return this.action;
        }

        public override void Enrich(IRequest<T> request)
        {
            logger.LogDebug("begin executing Enrich");
            
            logger.LogDebug("end executing Enrich");
            throw new NotImplementedException();
        }

        public override void Prepare(IOperationAction<T, U, V> operationAction)
        {
            logger.LogDebug("begin executing Prepare");

            logger.LogDebug("end executing Prepare");
            throw new NotImplementedException();
        }

        public override void Strip(IResponse<U> response)
        {
            logger.LogDebug("begin executing Strip");

            logger.LogDebug("end executing Strip");
            throw new NotImplementedException();
        }

    }
}
