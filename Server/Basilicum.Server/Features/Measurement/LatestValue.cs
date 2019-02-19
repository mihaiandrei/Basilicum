namespace Basilicum.Server.Features.Measurement
{
    using Basilicum.Server.Infrastructure;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class LatestValue
    {
        public class Query : IRequest<double?>
        {
            public int ParameterId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, double?>
        {
            private readonly DatabaseContext context;

            public QueryHandler(DatabaseContext context)
            {
                this.context = context;
            }

            public async Task<double?> Handle(Query request, CancellationToken cancellationToken)
            {
                var measurement = await context.Measurement
                                    .OrderByDescending(m => m.Date)
                                    .FirstOrDefaultAsync(m => m.ParameterId == request.ParameterId);
                return measurement?.Value;
            }
        }
    }
}
