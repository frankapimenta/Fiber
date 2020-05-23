namespace Fiber.Interfaces
{
	public interface IProtocol<T, U> where T : class, new() where U : class, new()
	{
		public abstract void Enrich(IRequest<T> request);

		public abstract void Strip(IResponse<U> response);
	}
}
