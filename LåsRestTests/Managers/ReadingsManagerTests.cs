using Microsoft.VisualStudio.TestTools.UnitTesting;
using LåsRest.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Library;

namespace LåsRest.Managers.Tests
{
    [TestClass()]
    public class ReadingsManagerTests
    {
        private static readonly ReadingsManager _manager = new ReadingsManager();

        [TestMethod()]
        public void GetReadingsTest()
        {
            //Arrange
            List<Reading> readings;
            int expectedCount = 17;
            int actualCount = 0;
            Type expectedType = typeof(List<Reading>);
            Type actualType;

            //Act
            readings = _manager.GetReadings();
            actualCount = readings.Count;
            actualType = readings.GetType();

            //Assert
            Assert.IsNotNull(readings);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedType, actualType);

        }

        [TestMethod()]
        public void AddReadingTest()
        {
            //Arrange
            var reading = new Reading()
                {Id = 2, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 1, Time = "2022-12-05 12:22:41"};
            string notExpectedTime = reading.Time;
            string actualTime;
            int notExpectedId = reading.Id;
            int actualId = 0;

            //Act
            var addedReading = _manager.AddReading(reading);
            actualTime = addedReading.Time;
            actualId = addedReading.Id;

            //Assert
            Assert.AreNotEqual(notExpectedId, actualId);
            Assert.AreNotEqual(notExpectedTime, actualTime);

        }
    }
}