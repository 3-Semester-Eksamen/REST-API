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
    }
}