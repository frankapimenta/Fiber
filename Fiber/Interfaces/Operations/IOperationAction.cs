namespace Fiber.Interfaces.Operations
{
    public interface IOperationAction<T, U, V> : IAction<T, U, V> where T : class, new() where U : class, new() where V : class, new()
    {
        public IOperationAction<T, U, V> OperationAction();

        public IOperationContext<V> OperationContext();

        public IOperationRequest<T> OperationRequest();

        public IOperationResponse<U> OperationResponse();
    }
}
