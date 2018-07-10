using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basilicum.Server.Test
{
	[TestClass]
	public class UnitTest1
	{
		

		[TestMethod]
			public void TestMethod1()
			{
				using (var scope = scopeFactory.CreateScope())
				{
					var mediator = scope.ServiceProvider.GetService<IMediator>();
					return mediator.Send(request);
				}
			}
	}
}
