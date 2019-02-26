namespace Basilicum.Server.Features.Parameter
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/parameter")]
    public class ParameterController : ControllerBase
    {
        private readonly IMediator mediator;
        public ParameterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Create.Command command)
        {
            var parameterId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { parameterId }, parameterId);
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<List.Model>> List(List.Query query)
        {
            var model = await mediator.Send(query);
            return model;
        }

        [HttpGet]
        [Route("{parameterId}")]
        public async Task<IActionResult> GetById([FromRoute]GetById.Query query)
        {
            var parameter = await mediator.Send(query);
            return Ok(parameter);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Delete.Command command)
        {
            await mediator.Send(command);
            return Ok();
        }
    }
}
