namespace Fiber.Interfaces
{
    public interface IValidation<T>
    {
        public IValidation<T> Model { get; }
        public virtual bool Valid()
        {
            return Model.Valid();
        }
    }
}
