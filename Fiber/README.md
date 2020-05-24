
# FIBER
# Author

I developed this framework in order to provide a convention framework for the development of API with .NET Core.

# Introdution
Fiber is a operation-protocol based miniframework to develop .NET Core Web Apis. It provide a collection of classes where one can develop an API in .NET Core by extending or reusing the given classes and methods.

# Operations and Protocols
  The base of the miniframework are *operations* and *protocols*.
  An **operation** is the means to run a **protocol**.
  A **protocol** is the collection of steps to perform an **operation** (ex.: Create a post object in db)

 ## Operation
 An operation can be injected via controller constructor to be then accessed across all the methods of that controller.
 The operation instance is then used to make a protocol instance based on the Tin, Tout and context objects.
 The protocol then provides a few methods to be overriden and this way provide the steps that make part of an operation execution.
 
```csharp
PostsController(ILogger<PostsController> logger, IOperation<PostCreateDTO, PostModelDTO, Dictionary<string, object>> operation)
		{
			this.logger = logger;
			this.operation = operation;
		} 
		
public async Task<ActionResult<string>> Create([Microsoft.AspNetCore.Mvc.FromBody] PostCreateDTO post) //PostOperationCreateData
		{
			await Task.Yield();

			operation.Make<PostCreateOperationProtocol<PostCreateDTO, PostModelDTO, Dictionary<string, object>>>(post); // should pass http request
			
			IOperationAction<PostCreateDTO, PostModelDTO, Dictionary<string, object>> action = operation.Execute();
			
			if (action.Response().Valid())
			{
				return action.OperationResponse().DataAsJsonString();
			}
			else {
				return action.OperationResponse().InvalidResponse().DataAsJsonString(); // PostModelDTO should be created where it wrapes model and errors
			}
		}
```
## Protocol

A protocol is a collection of steps to perform an operation (such as a creation of a Post object in db).
The protocol is based on Tin, Tout and context objects wraped under an action scope that enables a collection of steps to perform the execution of an operation.

```csharp
public class PostCreateOperationProtocol<T, U, V> : OperationProtocol<T, U, V> where T : class, new() where U : class, new() where V : class, new()
    {
        public PostCreateOperationProtocol()  { }
        
        // can inject as many services as wanted
        public PostCreateOperationProtocol(/* ICoreApiClient client, */ ILogger logger, IOperationAction<T, U, V> action) : base(logger, action)
        {

        }

        public override IOperationAction<T, U, V> Perform(IOperationAction<T, U, V> operationAction)
        {
            return action;
        }


        public override IOperationAction<T, U, V> CreateInvalidResponse(IOperationAction<T, U, V> action)
        {
            // get model errors - ModelDTO.Errors
            var errors = new List<IError>();
            IInvalidResponse<IError> invalidResponse = new InvalidResponse<IError>(errors);
            // create new action with new invalid response
            return AddInvalidResponseToAction(action, invalidResponse); ;
        }

        public override void Enrich(IRequest<T> request)
        {
            logger.LogDebug("begin executing Enrich");
            
            logger.LogDebug("end executing Enrich");
            throw new NotImplementedException();
        }

        public override void Finalize(IOperationAction<T, U, V> operationAction)
        {
            logger.LogDebug("begin executing Finalize");

            logger.LogDebug("end executing Finalize");
        }

        public override void Prepare(IOperationAction<T, U, V> operationAction)
        {
            logger.LogDebug("begin executing Prepare");

            logger.LogDebug("end executing Prepare");
        }

        public override void Strip(IResponse<U> response)
        {
            logger.LogDebug("begin executing Strip");

            logger.LogDebug("end executing Strip");
        }

    }
}
```
The developer only has to define those steps (methods) to enable then the execution of the operation by 
```csharp
# ProtocolClass#Call();

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
```


The controller then as access to either a valid or invalid response in json with either the new data model or a collection of errors to send back to the client call.

## Protocol steps
Next follows a collection of method signatures in order of execution that represent the steps a protocol has.

This next step allows the developer to prepare the action's fields before performing the main execution of the operation.

```csharp
public override void Prepare(IOperationAction<T, U, V> operationAction);
```

<br>
This next step definition allows the developer to add (enrich) the request data sent with aditional properties.

```csharp
public override void Enrich(IRequest<T> request);
```

<br>
This next step definition the "method": This method must be used by the developer to perform calls to other services and this way develop the intent of the operation. For example: In this method the developer would call a service to save the post and save the response in the response action field.

```csharp
public override IOperationAction<T, U, V> Perform(IOperationAction<T, U, V> operationAction);
```

<br>
This method allows the developer to strip properties from the action's response (avoid passing internal data to the client call).

```csharp
public override void Strip(IResponse<U> response);
```

<br>
This method is the last step of a protocol and enables the developer to do last changes in the action fields to be returned to the controller calling the operation.

```csharp
public override void Finalize(IOperationAction<T, U, V> operationAction);
```

# Response validation
In order to validate a response (i.e. validate a model) the Fiber provides a simple implementation of an Adapter.

```csharp
  public interface IValidation<T>
    {
        public T Model { get;  }
        public bool Valid();

    }
    
   public class ValidationAdapter<T> : IValidation<T>
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
```
In case of this adapter not being useful to you, you must create yours, inherited from *ValidationAdapter* class and then override the method **OperationProtocol#Call** in your Protocol implementation.

```csharp
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
```

Check *OperationProtocol.cs* file for further details.

# Errors
In order to create errors on validation you have to implement the method of interface *IOperationProtocolUtils*

```csharp
public abstract IOperationAction<T, U, V> CreateInvalidResponse(IOperationAction<T, U, V> action);
```
You can use the given *Error* class for what or create your one and then use the respective AddError overloaded method to use in your implementation of *#CreateInvalidResponse*.