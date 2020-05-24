using System.Collections.Generic;

namespace Fiber.Interfaces
{
    public interface IInvalidResponse<IError> : IResponse<List<IError>>
    {
        public bool Invalid();

        public void Clear();

        public IError AddError(string title, string message);

        public IError AddError(IError error);

        public List<IError> Errors();

    }
}
