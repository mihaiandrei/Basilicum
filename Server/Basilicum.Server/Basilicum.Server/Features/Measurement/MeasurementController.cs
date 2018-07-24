namespace Basilicum.Server.Features.Measurement
{
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	[Route("api/mesurement")]
	public class MeasurementController : ControllerBase
	{
		private readonly IMediator mediator;
		public MeasurementController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody]Create.Command command)
		{
			await mediator.Send(command);
			return Ok();
		}

		[HttpGet]
		[Route("list")]
		public async Task<List<List.Model>> List(List.Query query)
		{
			var model = await mediator.Send(query);
			return model;
		}
	}
}
