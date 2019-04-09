namespace Basilicum.Server.Features.Parameter
{
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
            public double Accuracy { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly DatabaseContext context;
            public Handler(DatabaseContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var parameter = new Parameter()
                {
                    Name = command.Name,
                    Accuracy = command.Accuracy
                };

                context.Parameter.Add(parameter);
                await context.SaveChangesAsync(cancellationToken);
                return parameter.Id;
            }
        }
    }
}
