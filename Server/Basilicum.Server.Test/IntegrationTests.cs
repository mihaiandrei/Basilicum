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

            var mesurementId = await Send(new Features.Measurement.Create.Command()
            {
                Value = value,
                ParameterId = parameterId
            });

            var measurement = await Send(new Features.Measurement.GetById.Query()
            {
                MeasurementId = mesurementId
            });

            Assert.AreEqual(value, measurement.Value);
        }

        [TestMethod]
        public async Task Should_Delete_Parameter()
        {
            var parameterName = "Test";
            var parameterId = await Send(new Features.Parameter.Create.Command()
            {
                Name = parameterName
            });

            var parameters = await Send(new Features.Parameter.List.Query() { SearchString = "Test" });

            var parameter = parameters.FirstOrDefault(m => m.Id == parameterId);

            Assert.AreEqual(parameterName, parameter.Name);

            await Send(new Features.Measurement.Create.Command()
            {
                Value = DateTime.Now.Minute,
                ParameterId = parameterId
            });

            Assert.IsTrue(await Send(new Features.Parameter.Delete.Command { ParameterId = parameterId }));
        }

        [TestMethod]
        public async Task Should_Create_NewMeasurementOnlyIfValueChanges()
        {
            var parameterId = await Send(new Features.Parameter.Create.Command()
            {
                Name = "Test"
            });

            var date = DateTime.UtcNow;
            var value = date.Minute;

            var mesurementId1 = await Send(new Features.Measurement.Create.Command()
            {
                Value = value,
                ParameterId = parameterId
            });

            var mesurementId2 = await Send(new Features.Measurement.Create.Command()
            {
                Value = value,
                ParameterId = parameterId
            });

            var measurement1 = await Send(new Features.Measurement.GetById.Query()
            {
                MeasurementId = mesurementId1
            });

            var measurement2 = await Send(new Features.Measurement.GetById.Query()
            {
                MeasurementId = mesurementId2
            });

            Assert.IsNull(measurement1);
            Assert.AreEqual(value, measurement2.Value);
        }
    }
}
