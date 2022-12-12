using Microsoft.VisualStudio.TestTools.UnitTesting;
using LåsRest.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Library;
using LåsRest.CustomExceptions;

namespace LåsRest.Managers.Tests
{
    [TestClass()]
    public class SensorsManagerTests
    {
        private static readonly SensorsManager _manager = new();

        [TestMethod()]
        public void GetSensorsTest()
        {
            //Arrange
            List<Sensor> sensors;
            int expectedCount = 5;
            int actualCount = 0;
            Type expectedType = typeof(List<Sensor>);
            Type actualType;

            //Act
            sensors = _manager.GetAllSensors();
            actualCount = sensors.Count;
            actualType = sensors.GetType();

            //Assert
            Assert.IsNotNull(sensors);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedType, actualType);
        }

        [TestMethod()]
        public void AddSensorSuccessTest()
        {
            //Arrange
            Sensor sensorToBeAdded = new Sensor() {MacAddress = "AA-00-04-00-YY-XX", Name = "Ny Dør"};
            Sensor actualAddedSensor;
            int initialCount = _manager.GetAllSensors().Count;
            int expectedCount = 6;
            int actualCount = 0;

            //Act
            actualAddedSensor = _manager.AddSensor(sensorToBeAdded);
            actualCount = _manager.GetAllSensors().Count;

            //Assert
            Assert.AreEqual(sensorToBeAdded.MacAddress, actualAddedSensor.MacAddress);
            Assert.AreEqual(sensorToBeAdded.Name, actualAddedSensor.Name);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(initialCount, actualCount);
        }

        [TestMethod]
        public void AddSensorAlreadyExistsTest()
        {
            //Arrange
            Sensor sensorToBeAdded = new Sensor() { MacAddress = "AA-00-04-00-XX-YY", Name = "Ny Dør" };
            int initialCount = _manager.GetAllSensors().Count;
            int actualCount = 0;

            //Act
            //Assert
            Assert.ThrowsException<AlreadyExists>(() => _manager.AddSensor(sensorToBeAdded));
            actualCount = _manager.GetAllSensors().Count;
            Assert.AreEqual(initialCount, actualCount);

        }
    }
}