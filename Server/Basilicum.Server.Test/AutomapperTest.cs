using AutoMapper;
using Basilicum.Server.Test.Helpers;
using FakeItEasy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Basilicum.Server.Test
{
	[TestClass]
	public class AutomapperTest
    {
		[TestMethod]
		public void AutomapperConfigurationTest()
		{
			//this is dumb
			SliceFixture.Dummy();
			Mapper.AssertConfigurationIsValid();
		}
    }
}
