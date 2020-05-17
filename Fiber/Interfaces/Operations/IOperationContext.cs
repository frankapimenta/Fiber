using System.Collections.Generic;

namespace Fiber.Interfaces.Operations
{
    public interface IOperationContext<T> : IContext<T>, IEnumerable<T>
    {
        public IOperationContext<T> OpContext();
    }
}
