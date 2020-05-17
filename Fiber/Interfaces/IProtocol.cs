namespace Fiber.Interfaces
{
	public interface IProtocol<T, U> where T : class, new() where U : class, new()
	{
		public void Enrich(IRequest<T> request);

		public void Strip(IResponse<U> response);
	}
}
