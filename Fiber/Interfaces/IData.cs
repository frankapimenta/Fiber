namespace Fiber.Interfaces
{
    public interface IData<T>
	{
		public T Data();

		public bool Valid(); // as authenticated

	}
}
