namespace Fiber.Interfaces
{
    public interface IContext<T>
    {
        public IContext<T> Context();
        public bool Valid(); // as authenticated
       
    }
}
