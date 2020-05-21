using Fiber.Interfaces;

namespace Fiber.Validations.Adapters
{
    public class ValidationAdapter<T> : IValidation<T>
    {
        private readonly IValidation<T> model;
        public ValidationAdapter(IValidation<T> model)
        {
            this.model = model;
        }

        public IValidation<T> Model => this.model;

        public virtual bool Valid()
        {
            return this.model.Valid();
        }
    }
}
