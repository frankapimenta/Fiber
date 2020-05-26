using Fiber.Contracts;
using Fiber.Interfaces;
using Fiber.Interfaces.Operations;
using Fiber.Interfaces.Protocols;
using Fiber.Protocols;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

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

		public virtual IOperation<T, U, V> Make<ProtocolClass>(T model) where ProtocolClass : class, new() 
		{
			IEnumerable<V> context = new V() as IEnumerable<V>;
			IOperationContext<V> operationContext = new OperationContext<V>(context);
			// TODO move request to context
			IOperationData<T> requestOperationData = new OperationData<T>(model);
			IOperationRequest<T> operationRequest = new OperationRequest<T>(requestOperationData);
			
			IOperationData<U> responseOperationData = new OperationData<U>(new U());
			IOperationResponse<U> operationResponse = new OperationResponse<U>(responseOperationData);
			
			IOperationAction<T, U, V> operationAction = new OperationAction<T, U, V>(operationRequest, operationResponse, operationContext);

			var protocol = CreateProtocolInstance<ProtocolClass>(logger, operationAction);

			this.protocol = protocol as OperationProtocol<T, U, V>;

			return this;
		}

		public virtual string Return(IOperationAction<T, U, V> operationAction)
		{
			if (operationAction.Response().Valid())
			{
				return operationAction.OperationResponse().DataAsJsonString();
			}
			else
			{
				return operationAction.OperationResponse().InvalidResponse().DataAsJsonString(); // PostModelDTO should be created where it wrapes model and errors
			}
		}

		private object CreateProtocolInstance<ProtocolClass>(ILogger logger, IOperationAction<T,U,V> operationAction)
		{
			return Activator.CreateInstance(typeof(ProtocolClass), new object[] { logger, operationAction });
		}

	}
}
