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
		public async Task Should_Create_NewParameter()
		{
			var parameterName = "Test";
			var parameterId = await Send(new Features.Parameter.Create.Command()
			{
				Name = parameterName
			});

			var parameters = await Send(new Features.Parameter.List.Query() { SearchString = "Test" });

			var parameter = parameters.FirstOrDefault(m => m.Id == parameterId);

			Assert.AreEqual(parameterName, parameter.Name);
		}


		[TestMethod]
		public async Task Should_Create_NewMeasurement()
		{
			var date = DateTime.UtcNow;
			var value = date.Minute;

			var parameterId = await Send(new Features.Parameter.Create.Command()
			{
				Name = "Test"
			});

			await Send(new Features.Measurement.Create.Command()
			{
				Date = date,
				Value = value,
				ParameterId = parameterId
			});

			var measurements = await Send(new Features.Measurement.List.Query()
			{
				StartDate = date.AddMilliseconds(-100),
				EndDate = date.AddMilliseconds(100),
				ParameterId = parameterId
			});

			var measurement = measurements.FirstOrDefault(m => m.Date == date);

			Assert.AreEqual(value, measurement.Value);
		}
	}
}
