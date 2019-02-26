namespace Basilicum.Server.Features.Measurement
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Basilicum.Server.Infrastructure;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class LatestValue
    {
        public class Query : IRequest<Model>
        {
            public int ParameterId { get; set; }
        }

        public class Model
        {
            public int Id { get; set; }
            public double Value { get; set; }
            public DateTime Date { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Model>
        {
            private readonly DatabaseContext context;
            private readonly IConfigurationProvider configurationProvider;
            public QueryHandler(DatabaseContext context,
                                IConfigurationProvider configurationProvider)
            {
                this.context = context;
                this.configurationProvider = configurationProvider;
            }

            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var measurement = await context.Measurement
                                                .Where(m => m.ParameterId == request.ParameterId)
                                                .ProjectTo<Model>(configurationProvider)
                                                .OrderByDescending(m => m.Date)
                                                .FirstOrDefaultAsync();
                return measurement;
            }
        }
    }
}
