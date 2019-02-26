namespace Basilicum.Server.Features.Parameter
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Basilicum.Server.Infrastructure;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetById
    {
        public class Query : IRequest<Model>
        {
            public int ParameterId { get; set; }
        }

        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Model>
        {
            private readonly DatabaseContext context;
            IConfigurationProvider configurationProvider;

            public QueryHandler(DatabaseContext context, IConfigurationProvider configurationProvider)
            {
                this.context = context;
                this.configurationProvider = configurationProvider;
            }

            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var parameter = await context.Parameter
                                               .ProjectTo<Model>(configurationProvider)
                                               .SingleOrDefaultAsync(m => m.Id == request.ParameterId);
                return parameter;
            }
        }
    }
}
