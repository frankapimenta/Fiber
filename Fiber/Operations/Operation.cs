using Fiber.Contracts;
using Fiber.Interfaces;
using Fiber.Interfaces.Operations;
using Fiber.Interfaces.Protocols;
using Fiber.Protocols;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiber.Operations
{
	public class Operation<T, U, V> : IOperation<T, U, V> where T : class, new() where U : class, new() where V : class, new()
	{
		public ILogger logger;
		protected IOperationProtocol<T, U, V> protocol;
		
		public Operation(ILogger logger)
		{
			this.logger = logger;
		}

		public IOperationAction<T, U, V> Execute()
		{
			return this.protocol.Call(this);//TODO pass the logger to call or self
		}

		public virtual IOperation<T, U, V> Make<ProtocolClass>(T request, T model) where ProtocolClass : class, new() 
		{
			IEnumerable<V> context = new V() as IEnumerable<V>;
			IOperationContext<V> operationContext = new OperationContext<V>(context);
			
			IOperationData<T> requestOperationData = new OperationData<T>(model);
			IOperationRequest<T> operationRequest = new OperationRequest<T>(request, requestOperationData);
			
			IOperationData<U> responseOperationData = new OperationData<U>(new U());
			IOperationResponse<U> operationResponse = new OperationResponse<U>(null, responseOperationData);
			
			IOperationAction<T, U, V> operationAction = new OperationAction<T, U, V>(operationRequest, operationResponse, operationContext);

			var protocol = 
				Activator.CreateInstance(typeof(ProtocolClass), new object[] { logger, operationAction });

			this.protocol = protocol as OperationProtocol<T, U, V>;

			return this;
		}

	}
}
