using Fiber.Interfaces;
using Fiber.Interfaces.Operations;
using Fiber.Interfaces.Protocols;
using Fiber.Operations;
using Microsoft.Extensions.Logging;

namespace Fiber.Protocols
{
	public abstract class OperationProtocol<T, U, V> : IOperationProtocol<T, U, V>  where T : class, new() where U : class, new() where V : class, new()
	{
		protected ILogger logger;
		protected IOperationAction<T, U, V> action;
		public OperationProtocol()  { }
		public OperationProtocol(ILogger logger, IOperationAction<T, U, V> action)
		{
			this.logger = logger;
			this.action = action;
		}
		public abstract IOperationAction<T, U, V> Call(Operation<T, U, V> operation);

		public abstract void Enrich(IRequest<T> request);

		public abstract void Prepare(IOperationAction<T, U, V> operationAction);

		public abstract void Strip(IResponse<U> response);
	}
}
