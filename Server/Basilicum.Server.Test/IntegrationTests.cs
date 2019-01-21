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
			var parameterId = await Send(new Features.Parameter.Create.Command()
			{
				Name = "Test"
			});

            var date = DateTime.UtcNow;
            var value = date.Minute;

            await Send(new Features.Measurement.Create.Command()
			{
				Value = value,
				ParameterId = parameterId
			});

			var measurements = await Send(new Features.Measurement.List.Query()
			{
				StartDate = date.AddMilliseconds(-100),
				EndDate = date.AddMilliseconds(100),
				ParameterId = parameterId
			});

			var measurement = measurements.FirstOrDefault();

			Assert.AreEqual(value, measurement.Value);
		}
	}
}
