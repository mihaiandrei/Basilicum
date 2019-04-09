
namespace Basilicum.Server.Features.Measurement
{
    using Basilicum.Server.Infrastructure;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Data.SqlClient;
    using System.Threading;
    using System.Threading.Tasks;

    public class Delete
    {
        public class Command : IRequest<bool>
        {
            public int ParameterId { get; set; }
            public DateTime OlderThen { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly DatabaseContext context;
            public Handler(DatabaseContext context)
            {
                this.context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var sqlCommand = "DELETE FROM [Measurement] " +
                                 "WHERE ParameterId = @ParameterId "+ 
                                 "AND Date < @OlderThen";

                var olderThenParameter = new SqlParameter("@OlderThen", System.Data.SqlDbType.DateTime)
                {
                    Value = request.OlderThen
                };
                int count = await context.Database.ExecuteSqlCommandAsync(sqlCommand,
                                        new SqlParameter("@ParameterId", request.ParameterId),
                                        olderThenParameter);
                return count > 0;        
            }
        }
    }
}
