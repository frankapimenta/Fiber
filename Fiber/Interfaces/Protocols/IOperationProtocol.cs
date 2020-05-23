using Fiber.Interfaces.Operations;
using Fiber.Operations;

namespace Fiber.Interfaces.Protocols
{
	public interface IOperationProtocol<T, U, V> : IProtocol<T, U> where T : class, new() where U : class, new() where V : class, new()
	{
		public IOperationAction<T, U, V> Call(Operation<T, U, V> operation);
		public abstract void Prepare(IOperationAction<T, U, V> operationAction);
		public abstract bool Validate<ValidationAdapterClass>(IOperationAction<T, U, V> operationAction);

		public abstract void Finalize(IOperationAction<T, U, V> operationAction);
	}
}
