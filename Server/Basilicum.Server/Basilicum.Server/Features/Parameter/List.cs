using AutoMapper.QueryableExtensions;
using Basilicum.Server.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basilicum.Server.Features.Parameter
{
	public class List
	{
		public class Query : IRequest<List<Model>> { }

		public class Model
		{
			public int Id { get; set; }
			public string Name { get; set; }
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
				return await context.Parameter
									.ProjectTo<Model>()
									.ToListAsync();
			}
		}
	}
}
