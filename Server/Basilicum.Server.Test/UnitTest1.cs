using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using static Basilicum.Server.Test.Helpers.SliceFixture;

namespace Basilicum.Server.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public async Task Should_Create_NewMeasurement()
		{
			await Send(new Features.Measurement.Create.Command()
			{
				Date = DateTime.Now,
				Value = 1
			});

			var measurements = await Send(new Features.Measurement.List.Query());
		}
	}
}
