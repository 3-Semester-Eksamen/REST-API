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
        };

        public List<Sensor> GetSensors()
        {
            var list = _sensors;
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
    }
}
