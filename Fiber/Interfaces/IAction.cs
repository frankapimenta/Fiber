namespace Fiber.Interfaces
{
    public interface IAction<T, U, V> where T : class, new() where U : class, new() where V : class, new()
    {
        public IContext<V> Context();

        public IRequest<T> Request();

        public IResponse<U> Response();

    }
}
