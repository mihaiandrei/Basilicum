
namespace Basilicum.Server.Features.Parameter
{
    using Basilicum.Server.Infrastructure;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class Delete
    {
        public class Command : IRequest<bool>
        {
            public int ParameterId { get; set; }
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
                var parameter = context.Parameter.SingleOrDefault(p => p.Id == request.ParameterId);

                if (parameter == null)
                    return false;

                context.Parameter.Remove(parameter);
                return await context.SaveChangesAsync(cancellationToken) > 0;
            }
        }
    }
}
