namespace Basilicum.Server.Features.Measurement
{
    using AutoMapper;
    using Basilicum.Server.Domain;
    using Basilicum.Server.Infrastructure;
    using FluentValidation;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Create
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(customer => customer.ParameterId).NotEmpty();
            }
        }

        public class Command : IRequest<int>
        {
            public double Value { get; set; }
            public int ParameterId { get; set; }
        }

        public class Handler : IRequestHandler<Command,int>
        {
            private readonly DatabaseContext context;

            public Handler(DatabaseContext context, IMapper mapper)
            {
                this.context = context;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
               var measurement = new Measurement()
                {
                    Date = DateTime.UtcNow,
                    ParameterId = request.ParameterId,
                    Value = request.Value
                };

                context.Measurement.Add(measurement);
                await context.SaveChangesAsync(cancellationToken);
                return measurement.Id;
            }
        }
    }
}
