using Fiber.Interfaces;
using Fiber.Interfaces.Operations;
using System;

namespace Fiber.Contracts
{
	public class OperationResponse<T> : IOperationResponse<T> where T : class, new()
	{
		private readonly IOperationData<T> operationData;

		public OperationResponse() { }
		public OperationResponse(IOperationData<T> operationData = null)
		{
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

		public IOperationResponse<T> OpResponse()
		{
			return this;
		}

		public IResponse<T> Response()
		{
			return this.OpResponse() as IResponse<T>;
		}

		public bool Valid()
		{
			return this.operationData.Valid();
		}
	}
}
