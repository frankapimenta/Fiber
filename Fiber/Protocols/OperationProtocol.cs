using Fiber.Errors;
using Fiber.Interfaces;
using Fiber.Interfaces.Operations;
using Fiber.Interfaces.Protocols;
using Fiber.Operations;
using Fiber.Validations.Adapters;
using Fiber.Validations.Responses;
using Microsoft.Extensions.Logging;
using System;

namespace Fiber.Protocols
{
	public abstract class OperationProtocol<T, U, V> : 
		IOperationProtocol<T, U, V> , IOperationProtocolUtils<T, U,V> where T : class, new() where U : class, new() where V : class, new()
	{
		protected ILogger logger;
		protected IOperationAction<T, U, V> action;
		public OperationProtocol()  { }
		public OperationProtocol(ILogger logger, IOperationAction<T, U, V> action)
		{
			this.logger = logger;
			this.action = action;
		}
		public IOperationAction<T, U, V> Call(Operation<T, U, V> operation)
		{
			logger.LogDebug("begin executing Call");

			Prepare(action);

			Enrich(action.OperationRequest());

			Perform(action);

			if (!Validate<ValidationAdapter<T>>(action))
			{
				CreateInvalidResponse(action);

			}
			else
			{
				return action;
			}

			Strip(action.OperationResponse());

			Finalize(action);

			logger.LogDebug("end executing Call");

			return this.action;
		}

		public abstract IOperationAction<T, U, V> CreateInvalidResponse(IOperationAction<T, U, V> action);

		public abstract void Enrich(IRequest<T> request);

		public abstract void Finalize(IOperationAction<T, U, V> operationAction);

		public abstract void Prepare(IOperationAction<T, U, V> operationAction);

		public abstract void Strip(IResponse<U> response);

		public virtual bool Validate<ValidationAdapterClass>(IOperationAction<T, U, V> operationAction)
		{
			IValidation<T> model = operationAction.OperationRequest().OpData().Valid() as IValidation<T>;

			var validationAdapter = CreateAdapterInstance<ValidationAdapterClass>(model) as IValidation<T>;

			return validationAdapter.Valid();
		}


		protected virtual object CreateAdapterInstance<ValidationAdapterClass>(IValidation<T> model)
		{
			return Activator.CreateInstance(typeof(ValidationAdapterClass), new object[] { model });
		}

		public IOperationAction<T, U, V> AddInvalidResponseToAction(IOperationAction<T, U, V> operationAction, IInvalidResponse<IError> invalidResponse)
		{
			action.OperationResponse().SetInvalidResponse(invalidResponse);

			return action;
		}

		public abstract IOperationAction<T, U, V> Perform(IOperationAction<T, U, V> operationAction);
	}
}
