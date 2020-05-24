using Fiber.Errors;
using Fiber.Interfaces;
using Fiber.Interfaces.Operations;
using Fiber.Validations.Responses;

namespace Fiber.Contracts
{
	public class OperationResponse<T> : IOperationResponse<T> where T : class, new()
	{
		private readonly IOperationData<T> operationData;
		private IInvalidResponse<IError> invalidResponse;

		public OperationResponse() { }
		public OperationResponse(IOperationData<T> operationData = null)
		{
			this.operationData = operationData;
		}

		public T Data()
		{
			return this.operationData.Data();
		}

		public string DataAsJson()
		{
			return this.operationData.DataAsJson();
		}

		public IInvalidResponse<IError> InvalidResponse()
		{
			return invalidResponse;
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

		public IInvalidResponse<IError> SetInvalidResponse(IInvalidResponse<IError> invalidResponse)
		{
			this.invalidResponse = invalidResponse;
			
			return invalidResponse;
		}

		public bool Valid()
		{
			return this.operationData.Valid();
		}

	}
}
