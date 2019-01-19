using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basilicum.Server.Features.Parameter
{
    [Route("api/parameter")]
    public class ParameterController : ControllerBase
    {
        private readonly ILogger<ParameterController> logger;
        private readonly IMediator mediator;
        public ParameterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Create.Command command)
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
