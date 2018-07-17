using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Basilicum.Server.Test.Helpers.SliceFixture;

namespace Basilicum.Server.Test
{
	[TestClass]
	public class IntegrationTests
	{
		[TestMethod]
		public async Task Should_Create_NewMeasurement()
		{
			var date = DateTime.UtcNow;
			var value = date.Minute;
			await Send(new Features.Measurement.Create.Command()
			{
				Date = date,
				Value = value
			});

			var measurements = await Send(new Features.Measurement.List.Query()
			{
				StartDate = date.AddMilliseconds(-10),
				EndDate = date.AddMilliseconds(10)
			});

			var measurement = measurements.FirstOrDefault(m => m.Date == date);

			Assert.AreEqual(value, measurement.Value);
		}
	}
}
