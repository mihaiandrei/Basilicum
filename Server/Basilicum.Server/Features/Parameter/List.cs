using AutoMapper;
using AutoMapper.QueryableExtensions;
using Basilicum.Server.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Basilicum.Server.Features.Parameter
{
    public class List
    {
        public class Query : IRequest<List<Model>>
        {
            public string SearchString { get; set; }
        }

        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly DatabaseContext context;
            private readonly IConfigurationProvider configurationProvider;

            public QueryHandler(DatabaseContext context, IConfigurationProvider configurationProvider)
            {
                this.context = context;
                this.configurationProvider = configurationProvider;

            }

            public async Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Parameter
                                    .Where(p=>p.Name.Contains(request.SearchString))
                                    .ProjectTo<Model>(configurationProvider)
                                    .ToListAsync();
            }

            public class ListProfile : Profile
            {
                public ListProfile()
                {
                    CreateMap<Basilicum.Server.Domain.Parameter, Model>();
                }
            }
        }
    }
}
