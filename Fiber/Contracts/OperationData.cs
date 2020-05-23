using Fiber.Interfaces;
using Fiber.Interfaces.Operations;

namespace Fiber.Contracts
{
	public class OperationData<T> : IOperationData<T>
	{
		protected readonly T operationData;

		public OperationData(T operationData)
		{
			this.operationData = operationData;
		}

		public T Data()
		{
			return this.operationData;
		}

		public IOperationData<T> OpData()
		{
			return this;
		}

		public bool Valid()
		{
			IData<T> data = this.operationData as IData<T>;
			return data.Valid();
		}
	}
}
