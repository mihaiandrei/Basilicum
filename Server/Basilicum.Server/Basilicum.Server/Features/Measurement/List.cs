namespace Basilicum.Server.Features.Measurement
{
	using AutoMapper;
	using Basilicum.Server.Infrastructure;
	using MediatR;
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;

	public class List
	{
		public class Query : IRequest<List<Model>>
		{ }

		public class Model
		{
			public double Value { get; set; }
			public DateTime Date { get; set; }
		}

		public class QueryHandler : IRequestHandler<Query, List<Model>>
		{
			private readonly DatabaseContext context;

			public QueryHandler(DatabaseContext context)
			{
				this.context = context;
			}

			public async Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
			{
				return await context.Measurements.ProjectToListAsync<Model>();
			}
		}
	}
}