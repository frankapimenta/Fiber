namespace Fiber.Interfaces
{
	public interface IResponse<T> where T : class, new()
	{
		public T Data();
		public string DataAsJson();
		public IResponse<T> Response();
		public bool Valid();
		
	}
}
