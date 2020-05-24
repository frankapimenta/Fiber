using Fiber.Errors;
using Fiber.Interfaces.Operations;

namespace Fiber.Interfaces.Protocols
{
    public interface IOperationProtocolUtils<T,U,V> where T : class, new() where U : class, new() where V : class, new()
    {
        public bool Validate<ValidationAdapterClass>(IOperationAction<T, U, V> operationAction);
        public IOperationAction<T, U, V> CreateInvalidResponse(IOperationAction<T, U, V> action);
        public IOperationAction<T, U, V> AddInvalidResponseToAction(IOperationAction<T, U, V> operationAction, IInvalidResponse<IError> invalidResponse);
    }
}
