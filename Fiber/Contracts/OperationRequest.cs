using System;
using Fiber.Interfaces;
using Fiber.Interfaces.Operations;

namespace Fiber.Contracts
{
	public class OperationRequest<T> : IOperationRequest<T> where T : class, new()
	{
		private readonly T operationRequest;
		private readonly IOperationData<T> operationData;

		public OperationRequest() { }
		public OperationRequest(T operationRequest = null, IOperationData<T> operationData = null)
		{
			this.operationRequest = operationRequest;
			this.operationData = operationData;
		}

		public T Data()
		{
			return this.operationData.Data();
		}

		public IOperationData<T> OpData()
		{
			return this.operationData;
		}

		public IOperationRequest<T> OpRequest()
		{
			return this;
		}

		public IRequest<T> Request()
		{
			return this.operationRequest as IRequest<T>;
		}

		public bool Valid()
		{
			return this.operationData.Valid();
		}
	}
}
