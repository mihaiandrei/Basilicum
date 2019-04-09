namespace Basilicum.Server.Features.Measurement
{
    using AutoMapper;
    using Basilicum.Server.Domain;
    using Basilicum.Server.Infrastructure;
    using FluentValidation;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
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

        public class Handler : IRequestHandler<Command, int>
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

                var parameterAccuracy = await context.Parameter
                                                    .Where(p => p.Id == request.ParameterId)
                                                    .Select(p => p.Accuracy)
                                                    .SingleAsync();

                var latestMeasurement = await context.Measurement
                                                    .OrderByDescending(m => m.Date)
                                                    .FirstOrDefaultAsync(m => m.ParameterId == request.ParameterId);

                if (latestMeasurement != null
                    && Math.Abs(latestMeasurement.Value - request.Value) < parameterAccuracy
                    && latestMeasurement.Date.AddHours(1) > DateTime.UtcNow)
                {
                    context.Measurement.Remove(latestMeasurement);
                }

                context.Measurement.Add(measurement);
                await context.SaveChangesAsync(cancellationToken);
                return measurement.Id;
            }
        }
    }
}
