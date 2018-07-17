namespace Basilicum.Server.Features.Measurement
{
	using AutoMapper;
	using Basilicum.Server.Domain;
	using Basilicum.Server.Infrastructure;
	using MediatR;
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class Create
	{
		public class Command : IRequest
		{
			public double Value { get; set; }
			public DateTime Date { get; set; }
			public int ParameterId { get; set; }
		}

		public class Handler : AsyncRequestHandler<Command>
		{
			private readonly DatabaseContext context;

			public Handler(DatabaseContext context)
			{
				this.context = context;
			}

			protected override async Task Handle(Command request, CancellationToken cancellationToken)
			{
				var measurement = Mapper.Map<Command, Measurement>(request);

				context.Measurement.Add(measurement);
				await context.SaveChangesAsync(cancellationToken);
			}
		}
	}
}
