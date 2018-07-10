namespace Basilicum.Server.Features.Measurement
{
	using AutoMapper;
	using Basilicum.Server.Domain;
	using Basilicum.Server.Infrastructure;
	using MediatR;
	using System;

	public class Create
	{
		public class Command : IRequest
		{
			public double Value { get; set; }
			public DateTime Date { get; set; }
		}

		public class Handler : RequestHandler<Command>
		{
			private readonly DatabaseContext context;

			public Handler(DatabaseContext context)
			{
				this.context = context;
			}

			protected override void Handle(Command message)
			{
				var measurement = Mapper.Map<Command, Measurement>(message);

				context.Measurements.Add(measurement);
			}
		}
	}
}
