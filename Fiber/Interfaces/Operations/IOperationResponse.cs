namespace Fiber.Interfaces.Operations
{
	public interface IOperationResponse<T> : IResponse<T> where T : class, new()
	{
		public IOperationData<T> OpData();

		public IOperationResponse<T> OpResponse();
		

	}
}
