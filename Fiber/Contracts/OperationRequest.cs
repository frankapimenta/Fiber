using Fiber.Interfaces;
using Fiber.Interfaces.Operations;

namespace Fiber.Contracts
{
	public class OperationRequest<T> : IOperationRequest<T> where T : class, new()
	{
		private readonly IOperationData<T> operationData;

		public OperationRequest() { }
		public OperationRequest( IOperationData<T> operationData = null)
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

		public IOperationRequest<T> OpRequest()
		{
			return this;
		}

		public IRequest<T> Request()
		{
			return this.OpRequest() as IRequest<T>;
		}  

		public bool Valid()
		{
			return this.operationData.Valid();
		}
	}
}
