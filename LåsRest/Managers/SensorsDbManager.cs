using Class_Library;
using LåsRest.CustomExceptions;

namespace LåsRest.Managers
{
    public class SensorsDbManager : ISensorsManager
    {
        private static readonly DbManager<Sensor> _dbManager = new DbManager<Sensor>();

        public List<Sensor> GetAssignedSensors()
        {
            var list = _dbManager.GetObjects().Result.FindAll(s => s.Name != "Unassigned");
            return list;
        }

        public List<Sensor> GetUnassignedSensors()
        {
            var list = _dbManager.GetObjects().Result.FindAll(s => s.Name == "Unassigned");
            return list;
        }

        public List<Sensor> GetAllSensors()
        {
            return _dbManager.GetObjects().Result;
        }

        public Sensor AddSensor(Sensor sensor)
        {
            sensor.Validate();
            var foundSensor = GetAllSensors().Find(s => s.MacAddress == sensor.MacAddress);
            if (foundSensor != null) throw new AlreadyExists("A sensor with this MacAddress already exists");
            var createdSensor = _dbManager.Add(sensor).Result;
            return createdSensor;
        }

        public Sensor UpdateSensorName(Sensor updatesSensor)
        {
            var sensor = GetAllSensors().Find(s => s.MacAddress == updatesSensor.MacAddress);
            if (sensor == null) throw new BadSearch("Sensor was not found");
            sensor.Name = updatesSensor.Name;
            sensor.Validate();
            var updatedSensor = _dbManager.Update(sensor).Result;
            return updatedSensor;
        }

        public bool SensorExists(string macAddress)
        {
            return GetAllSensors().Exists(sensor => sensor.MacAddress == macAddress);

        }
    }
}
