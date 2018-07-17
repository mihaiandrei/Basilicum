using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;

namespace Basilicum.Server.Test.Helpers
{
	public class SliceFixture
	{
		private static readonly IServiceScopeFactory scopeFactory;

		static SliceFixture()
		{
			var host = A.Fake<IHostingEnvironment>();
			A.CallTo(() => host.ContentRootPath).Returns(Directory.GetCurrentDirectory());

			var services = new ServiceCollection();
			var startup = new Startup(host);
			startup.ConfigureServices(services);

			var provider = services.BuildServiceProvider();
			scopeFactory = provider.GetService<IServiceScopeFactory>();
		}

		public static async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
		{
			using (var scope = scopeFactory.CreateScope())
			{
				var mediator = scope.ServiceProvider.GetService<IMediator>();
				return await mediator.Send(request);
			}
		}

		public static void Dummy() { }
	}
}
