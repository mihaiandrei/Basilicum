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

        [HttpPost]
        [Route("create/{parameterId}/{value}")]
        public async Task<IActionResult> CreateFromRoute([FromRoute]int parameterId, [FromRoute]double value)
        {
            var command = new Create.Command()
            {
                ParameterId = parameterId,
                Value = value
            };
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
