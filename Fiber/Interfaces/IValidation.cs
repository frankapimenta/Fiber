namespace Fiber.Interfaces
{
    public interface IValidation<T>
    {
        public T Model { get;  }
        public bool Valid();

    }
}
