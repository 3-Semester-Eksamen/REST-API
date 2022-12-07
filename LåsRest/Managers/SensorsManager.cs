using Class_Library;
using LåsRest.CustomExceptions;

namespace LåsRest.Managers
{
    public class SensorsManager
    {
        private static int _nextId = 1;

        private static readonly List<Sensor> _sensors = new List<Sensor>()
        {
            new Sensor() {MacAddress = "AA-00-04-00-XX-YY", Name = "Det Hemmelige Laboratorie"},
            new Sensor() {MacAddress = "AS-00-04-00-XX-XY", Name = "Bagindgang"},
            new Sensor() {MacAddress = "FY-00-04-12-XX-YY", Name = "Andreas' mors værelse"},
            new Sensor() {MacAddress = "BY-09-05-10-XX-YY", Name = "Container"},
            new Sensor() {MacAddress = "AA-90-87-10-XX-YY", Name = "Dør2"},
            new Sensor() {MacAddress = "AA-90-87-10-XX-YY", Name = "Unassigned"},
            new Sensor() {MacAddress = "AA-99-84-10-XX-YY", Name = "Unassigned"},
            new Sensor() {MacAddress = "AA-12-82-10-XX-YY", Name = "Unassigned"},
            new Sensor() {MacAddress = "AA-21-67-10-XX-YY", Name = "Unassigned"},
        };

        public List<Sensor> GetSensors()
        {
            var list = _sensors.FindAll(s => s.Name != "Unassigned");
            return list;
        }

        public List<Sensor> GetUnassignedSensors()
        {
            var list = _sensors.FindAll(s => s.Name == "Unassigned");
            return list;
        }

        public Sensor AddSensor(Sensor sensor)
        {
            sensor.Validate();
            foreach (var s in _sensors)
            {
                if (s.MacAddress == sensor.MacAddress) throw new AlreadyExists("The sensor already exists");
            }
            _sensors.Add(sensor);
            return sensor;
        }

        public Sensor UpdateSensorName(Sensor updatesSensor)
        {
            var sensor = _sensors.Find(s => s.MacAddress == updatesSensor.MacAddress);
            if (sensor == null) throw new ArgumentNullException("macAddress", "Sensor was not found");
            sensor.Name = updatesSensor.Name;
            sensor.Validate();
            return sensor;
        }

        public bool SensorExists(string macAddress)
        {
            return _sensors.Exists(sensor => sensor.MacAddress == macAddress);

        }
    }
}
