using Fiber.Interfaces.Operations;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Fiber.Interfaces
{
	public interface IOperation<T, U, V> where T : class, new() where U : class, new() where V : class, new()
	{
		public abstract IOperation<T, U, V> Make<ProtocolClass>(T model) where ProtocolClass : class, new();
		public IOperationAction<T, U, V> Execute();
	}
}
