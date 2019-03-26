namespace Basilicum.Server.Features.Measurement
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/measurement")]
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
            var measurementId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { measurementId }, measurementId);
        }

        [HttpPost]
        [Route("create/{ParameterId}/{Value}")]
        public async Task<IActionResult> CreateFromRoute([FromRoute]Create.Command command)
        {
            var measurementId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { measurementId }, measurementId);
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<List.Model>> List(List.Query query)
        {
            var model = await mediator.Send(query);
            return model;
        }

        [HttpGet]
        [Route("{measurementId}")]
        public async Task<IActionResult> GetById([FromRoute]GetById.Query query)
        {
            var measurement = await mediator.Send(query);
            return Ok(measurement);
        }

        [HttpGet]
        [Route("{ParameterId}/latest")]
        public async Task<IActionResult> GetLatestMeasurement([FromRoute]LatestValue.Query query)
        {
            var measurement = await mediator.Send(query);
            return Ok(measurement);
        }
    }
}
