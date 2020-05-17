namespace Fiber.Interfaces.Operations
{
    public interface IOperationData<T> : IData<T>
    {
        public IOperationData<T> OpData();
    }
}
