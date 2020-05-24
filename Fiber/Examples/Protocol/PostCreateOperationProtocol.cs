using Fiber.Contracts;
using Fiber.Errors;
using Fiber.Interfaces;
using Fiber.Interfaces.Operations;
using Fiber.Operations;
using Fiber.Protocols;
using Fiber.Validations.Adapters;
using Fiber.Validations.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Fiber.Examples.Protocol
{
    public class PostCreateOperationProtocol<T, U, V> : OperationProtocol<T, U, V> where T : class, new() where U : class, new() where V : class, new()
    {
        public PostCreateOperationProtocol()  { }
        
        // can inject as many services as wanted
        public PostCreateOperationProtocol(/* ICoreApiClient client, */ ILogger logger, IOperationAction<T, U, V> action) : base(logger, action)
        {

        }

        public override IOperationAction<T, U, V> Perform(IOperationAction<T, U, V> operationAction)
        {
            return action;
        }


        public override IOperationAction<T, U, V> CreateInvalidResponse(IOperationAction<T, U, V> action)
        {
            // get model errors - ModelDTO.Errors
            var errors = new List<IError>();
            // Add errors
            IInvalidResponse<IError> invalidResponse = new InvalidResponse<IError>(errors);
            // create new action with new invalid response
            return AddInvalidResponseToAction(action, invalidResponse); ;
        }

        public override void Enrich(IRequest<T> request)
        {
            logger.LogDebug("begin executing Enrich");
            
            logger.LogDebug("end executing Enrich");
            throw new NotImplementedException();
        }

        public override void Finalize(IOperationAction<T, U, V> operationAction)
        {
            logger.LogDebug("begin executing Finalize");

            logger.LogDebug("end executing Finalize");
        }

        public override void Prepare(IOperationAction<T, U, V> operationAction)
        {
            logger.LogDebug("begin executing Prepare");

            logger.LogDebug("end executing Prepare");
        }

        public override void Strip(IResponse<U> response)
        {
            logger.LogDebug("begin executing Strip");

            logger.LogDebug("end executing Strip");
        }

    }
}
