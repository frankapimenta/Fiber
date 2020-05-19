using Fiber.Examples.Data;
using Fiber.Examples.Data.Model;
using Fiber.Examples.Protocol;
using Fiber.Interfaces;
using Fiber.Interfaces.Operations;
using Fiber.Operations;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace Fiber.Examples.Controllers
{
	class PostsController : Controller
	{
		private readonly ILogger logger;
		PostsController(ILogger<PostsController> logger)
		{
			this.logger = logger;
		}
		public async Task<IResponse<PostOperationModel>> Create([FromBody] PostCreateOperationModel post) //PostOperationCreateData
		{
			await Task.Yield();

			IOperation<PostCreateOperationModel, PostOperationModel, Dictionary<string, object>> operation =
				new Operation<PostCreateOperationModel, PostOperationModel, Dictionary<string, object>>(logger);

			operation = operation.Make<PostCreateOperationProtocol<PostCreateOperationModel, PostOperationModel, Dictionary<string, object>>>(post); // should pass http request
			
			IOperationAction<PostCreateOperationModel, PostOperationModel, Dictionary<string, object>> action = operation.Execute();
			
			if (action.Response().Valid())
			{
				//return Ok(Response);
				return action.Response();
			}
			else {
				//return BadResponse(response);
				return action.Response();
			}
		}
	}

}
