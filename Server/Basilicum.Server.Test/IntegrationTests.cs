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

            var parameter = await Send(new Features.Parameter.GetById.Query() { ParameterId = parameterId });

            Assert.AreEqual(parameterName, parameter.Name);
        }

        [TestMethod]
        public async Task Should_ListParameters()
        {
            var parameterName = "Test";
            var parameterId = await Send(new Features.Parameter.Create.Command()
            {
                Name = parameterName
            });

            var parameters = await Send(new Features.Parameter.List.Query() { SearchString = parameterName });
            var parameter = parameters.First();
            Assert.IsTrue(parameter.Name.Contains(parameterName));
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
        public async Task Should_Delete_MeasurementsOlderThen()
        {
            var parameterName = "Test";
            var parameterId = await Send(new Features.Parameter.Create.Command()
            {
                Name = parameterName
            });

            await Send(new Features.Measurement.Create.Command()
            {
                Value = DateTime.Now.Minute,
                ParameterId = parameterId
            });

            await Send(new Features.Measurement.Delete.Command()
            {
                OlderThen = DateTime.Now,
                ParameterId = parameterId
            });

            var measurements = await Send(new Features.Measurement.List.Query()
            {
                ParameterId = parameterId
            });

            Assert.IsFalse(measurements.Any());
        }

        [TestMethod]
        public async Task Should_Create_NewMeasurementOnlyIfValueChanges()
        {
            var parameterId = await Send(new Features.Parameter.Create.Command()
            {
                Name = "Test",
                Accuracy = 0.1
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

        [TestMethod]
        public async Task Should_LatestValue()
        {
            var parameterId = await Send(new Features.Parameter.Create.Command()
            {
                Name = "Test"
            });

            await Send(new Features.Measurement.Create.Command()
            {
                Value = 1,
                ParameterId = parameterId
            });

            await Send(new Features.Measurement.Create.Command()
            {
                Value = 2,
                ParameterId = parameterId
            });

            var latestMeasurement = await Send(new Features.Measurement.LatestValue.Query()
            {
                ParameterId = parameterId
            });

            Assert.AreEqual(2, latestMeasurement.Value);
        }
    }
}
