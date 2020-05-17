namespace Fiber.Interfaces.Operations
{
	public interface IOperationRequest<T> : IRequest<T> where T : class, new()
	{
		public IOperationData<T> OpData();

		public IOperationRequest<T> OpRequest();

	}
}
