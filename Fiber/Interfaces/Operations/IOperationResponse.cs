using Fiber.Errors;
using Fiber.Validations.Responses;

namespace Fiber.Interfaces.Operations
{
	public interface IOperationResponse<T> : IResponse<T> where T : class, new()
	{
		public IOperationData<T> OpData();

		public IOperationResponse<T> OpResponse();

		public IInvalidResponse<IError> InvalidResponse();

		public IInvalidResponse<IError> SetInvalidResponse(IInvalidResponse<IError> invalidResponse);

	}
}
