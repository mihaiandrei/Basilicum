namespace Basilicum.Server.Features.Parameter
{
    using AutoMapper;
    using Basilicum.Server.Domain;
    using Basilicum.Server.Infrastructure;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class Create
    {
        public class Command : IRequest<int>
        {
            public string Name { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly DatabaseContext context;
            private readonly IMapper mapper;
            public Handler(DatabaseContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var parameter = mapper.Map<Command, Parameter>(request);

                context.Parameter.Add(parameter);
                await context.SaveChangesAsync(cancellationToken);
                return parameter.Id;
            }
        }
    }
}
