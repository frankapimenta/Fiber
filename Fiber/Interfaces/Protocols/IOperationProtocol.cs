using Fiber.Errors;
using Fiber.Interfaces.Operations;
using Fiber.Operations;

namespace Fiber.Interfaces.Protocols
{
	public interface IOperationProtocol<T, U, V> : IProtocol<T, U> where T : class, new() where U : class, new() where V : class, new()
	{
		public IOperationAction<T, U, V> Perform(IOperationAction<T, U, V> operationAction);
		public IOperationAction<T, U, V> Call(Operation<T, U, V> operation);
		public void Prepare(IOperationAction<T, U, V> operationAction);
		public void Finalize(IOperationAction<T, U, V> operationAction);
	}
}
