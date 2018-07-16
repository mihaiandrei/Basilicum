using Microsoft.VisualStudio.TestTools.UnitTesting;
using Basilicum.Server.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using AutoMapper;

namespace Basilicum.Server.Test
{
	[TestClass]
	public class AutomapperTest
    {
		[TestMethod]
		public void AutomapperConfigurationTest()
		{
			var services = new ServiceCollection();

			Mapper.AssertConfigurationIsValid();
		}
    }
}
