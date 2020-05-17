using Fiber.Interfaces.Operations;
using System.Threading.Tasks;

namespace Fiber.Interfaces
{
	public interface IOperation<T, U, V> where T : class, new() where U : class, new() where V : class, new()
	{
		public abstract IOperation<T, U, V> Make<ProtocolClass>(T request, T model) where ProtocolClass : class, new();
		public IOperationAction<T, U, V> Execute();
	}
}
