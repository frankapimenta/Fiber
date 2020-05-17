using Fiber.Interfaces;
using Fiber.Interfaces.Operations;

namespace Fiber.Contracts
{
    public class OperationAction<T, U, V> : IOperationAction<T, U, V> where T : class, new() where U : class, new() where V : class, new()
    {
        private readonly IOperationRequest<T> operationRequest;
        private readonly IOperationResponse<U> operationResponse;
        private readonly IOperationContext<V> operationContext;

        public OperationAction(IOperationRequest<T> operationRequest, IOperationResponse<U> operationResponse, IOperationContext<V> operationContext)
        {
            this.operationRequest = operationRequest;
            this.operationResponse = operationResponse;
            this.operationContext = operationContext;
        }

        public IContext<V> Context()
        {
            return operationContext.Context();
        }

        public IOperationContext<V> OperationContext()
        {
            return operationContext;
        }

        public IOperationRequest<T> OperationRequest()
        {
            return operationRequest;
        }

        public IOperationResponse<U> OperationResponse()
        {
            return operationResponse;
        }

        public IRequest<T> Request()
        {
            return operationRequest.Request();
        }

        public IResponse<U> Response()
        {
            return operationResponse.Response();
        }

        IOperationAction<T, U, V> IOperationAction<T, U, V>.OperationAction()
        {
            return this;
        }
    }
}
