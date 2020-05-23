using System.Collections;
using System.Xml.Serialization;

namespace Fiber.Interfaces
{
    public interface IValidation<T>
    {
        public T Model { get;  }
        public bool Valid();

    }
}
