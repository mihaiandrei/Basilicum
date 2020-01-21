
namespace Basilicum.Server.Features.Measurement
{
    using Basilicum.Server.Infrastructure;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
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
                int count = await context.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM [Measurement] WHERE ParameterId = {request.ParameterId} AND Date < { request.OlderThen.ToString()}");
                return count > 0;
            }
        }
    }
}
