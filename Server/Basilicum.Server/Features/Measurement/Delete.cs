
namespace Basilicum.Server.Features.Measurement
{
    using Basilicum.Server.Infrastructure;
    using MediatR;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class Delete
    {
        public class Command : IRequest<bool>
        {
            public int ParameterId { get; set; }
            public DateTime OlderThen { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly DatabaseContext context;
            public Handler(DatabaseContext context)
            {
                this.context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var measurements = context.Measurement.Where(m => m.Id == request.ParameterId
                                                                && m.Date < request.OlderThen);
                context.Measurement.RemoveRange(measurements);
                return await context.SaveChangesAsync(cancellationToken) > 0;
            }
        }
    }
}
