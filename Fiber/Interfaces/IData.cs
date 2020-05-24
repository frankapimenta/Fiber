namespace Fiber.Interfaces
{
    public interface IData<T>
	{
		public T Data();

		public string DataAsJson();

		public bool Valid(); // as authenticated

	}
}
