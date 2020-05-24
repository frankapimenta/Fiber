/*using Fiber.Errors;
using Fiber.Examples.Data;
using Fiber.Examples.Data.Model;
using Fiber.Examples.Protocol;
using Fiber.Interfaces;
using Fiber.Interfaces.Operations;
using Fiber.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
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

		[Consumes(MediaTypeNames.Application.Json)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Create([FromBody] PostCreateOperationDTO post) //PostOperationCreateData
		{
			await Task.Yield();

			IOperation<PostCreateOperationDTO, PostOperationModel, Dictionary<string, object>> operation =
				new Operation<PostCreateOperationDTO, PostOperationModel, Dictionary<string, object>>(logger);

			operation = operation.Make<PostCreateOperationProtocol<PostCreateOperationDTO, PostOperationModel, Dictionary<string, object>>>(post); // should pass http request
			
			IOperationAction<PostCreateOperationDTO, PostOperationModel, Dictionary<string, object>> action = operation.Execute();
			
			if (action.Response().Valid())
			{
				return Ok(action.OperationResponse());
			}
			else {
				return BadRequestResult(action.OperationResponse().InvalidResponse());
			}
		}
	}

}*/
