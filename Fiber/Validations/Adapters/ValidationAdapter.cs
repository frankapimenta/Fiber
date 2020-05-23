using Fiber.Interfaces;

namespace Fiber.Validations.Adapters
{
    public class ValidationAdapter<T> : IValidation<T> // TODO enable getting model to get errors for invalid responses
    {
        public ValidationAdapter(T model)
        {
            this.Model = model;
        }

        public T Model { get; }

        public virtual bool Valid()
        {
            return ((IValidation<T>)this.Model).Valid();
        }

    }
}
