namespace Basilicum.Server.Features.Measurement
{
	using AutoMapper.QueryableExtensions;

	using Basilicum.Server.Infrastructure;
	using MediatR;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;

	public class List
	{
		public class Query : IRequest<List<Model>>
		{
			public DateTime StartDate { get; set; }
			public DateTime EndDate { get; set; }
		}

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
				return await context.Measurements
									.Where(m => m.Date >= request.StartDate &&
												m.Date <= request.EndDate)
									.ProjectTo<Model>()
									.ToListAsync();
			}
		}
	}
}