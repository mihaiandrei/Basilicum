

namespace Basilicum.Server.Features.Measurement
{
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class MeasurementController : Controller
	{
		private readonly IMediator _mediator;
		public MeasurementController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create(Create.Command command)
		{
			await _mediator.Send(command);
			return Ok();
		}

		public async Task<List<List.Model>> List(List.Query query)
		{
			var model = await _mediator.Send(query);

			return model;
		}
	}
}
