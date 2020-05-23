using System.Collections.Generic;

namespace Fiber.Interfaces
{
    public interface IInvalidResponse<T> : IResponse<List<T>>
    {
        public bool Invalid();

        public void Clear();

        public T AddError(string title, string message);

        public string DataAsJson();
        
    }
}
