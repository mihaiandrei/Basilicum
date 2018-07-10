using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Basilicum.Server.Test.Helpers
{
	public class SliceFixture
	{
		private readonly IServiceScopeFactory scopeFactory;
		public SliceFixture()
		{
			var services = new ServiceCollection();
			var provider = services.BuildServiceProvider();
			scopeFactory = provider.GetService<IServiceScopeFactory>();
		}

		public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
		{
			using (var scope = scopeFactory.CreateScope())
			{
				var mediator = scope.ServiceProvider.GetService<IMediator>();
				return await mediator.Send(request);
			}
		}
	}
}
