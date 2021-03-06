﻿using Fiber.Examples.Data;
using Fiber.Examples.Data.ModelDTO;
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
using System.Web.Mvc;

namespace Fiber.Examples.Controllers
{
	class PostsController : Controller
	{
		private readonly ILogger logger;
		private readonly IOperation<PostCreateDTO, PostModelDTO, Dictionary<string, object>> operation;
		
		PostsController(ILogger<PostsController> logger)
		{
			this.logger = logger;
		}
		
		PostsController(ILogger<PostsController> logger, IOperation<PostCreateDTO, PostModelDTO, Dictionary<string, object>> operation)
		{
			this.logger = logger;
			this.operation = operation;
		}

		[System.Web.Http.HttpPost]
		[Consumes(MediaTypeNames.Application.Json)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<string>> Create([Microsoft.AspNetCore.Mvc.FromBody] PostCreateDTO post) //PostOperationCreateData
		{
			await Task.Yield();

			/*IOperation<PostCreateDTO, PostModelDTO, Dictionary<string, object>> operation =
				new Operation<PostCreateDTO, PostModelDTO, Dictionary<string, object>>(logger);

			operation =*/
			operation.Make<PostCreateOperationProtocol<PostCreateDTO, PostModelDTO, Dictionary<string, object>>>(post); // should pass http request
			
			IOperationAction<PostCreateDTO, PostModelDTO, Dictionary<string, object>> action = operation.Execute();
			
			return operation.Return(action);
		}
	}

}
