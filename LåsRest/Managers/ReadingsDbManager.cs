using Class_Library;
using System.Xml.Linq;

namespace LåsRest.Managers
{
    public class ReadingsDbManager : IReadingsManager
    {
        private static readonly DbManager<Reading> _dbManager = new DbManager<Reading>();
        private static readonly SensorsDbManager _sensorsDbManager = new SensorsDbManager();

        public List<Reading> GetReadings()
        {
            var list = _dbManager.GetObjects().Result;
            return list;
        }

        public Reading AddReading(Reading reading)
        {
            reading.Time = DateTime.Now.ToString();
            reading.Id = 0;
            reading.Validate();
            var createdReading = _dbManager.Add(reading).Result;
            if (!_sensorsDbManager.SensorExists(createdReading.MacAddressSensor))
                _sensorsDbManager.AddSensor(new Sensor() { Name = "Unassigned", MacAddress = createdReading.MacAddressSensor });

            return createdReading;
        }
    }
}
