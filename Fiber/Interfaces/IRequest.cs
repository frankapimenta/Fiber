namespace Fiber.Interfaces
{
	public interface IRequest<T> where T : class, new()
	{
		public T Data();
		
		public IRequest<T> Request();

		public bool Valid();

	}
}
