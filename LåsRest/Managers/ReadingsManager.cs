using Class_Library;

namespace LåsRest.Managers
{
    public class ReadingsManager : IReadingsManager
    {
        private static int _nextId = 1;

        private static readonly List<Reading> _data = new()
        {
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 1, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AS-00-04-00-XX-XY", OpenedBy = 2, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-90-87-10-XX-YY", OpenedBy = 3, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 4, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AS-00-04-00-XX-XY", OpenedBy = 1, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "BY-09-05-10-XX-Y", OpenedBy = 1, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 2, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 3, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "FY-00-04-12-XX-YY", OpenedBy = 5, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 5, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "BY-09-05-10-XX-Y", OpenedBy = 2, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-90-87-10-XX-YY", OpenedBy = 2, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "FY-00-04-12-XX-YY", OpenedBy = 1, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 4, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 5, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "BY-09-05-10-XX-Y", OpenedBy = 4, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-90-87-99-XX-YY", OpenedBy = 3, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-90-87-99-XX-YY", OpenedBy = 7, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-99-84-10-XX-YY", OpenedBy = 5, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-99-84-10-XX-YY", OpenedBy = 1, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-12-82-10-XX-YY", OpenedBy = 4, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-12-82-10-XX-YY", OpenedBy = 6, Time = DateTime.Now.ToString()},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-21-67-10-XX-YY", OpenedBy = 4, Time = DateTime.Now.ToString()},
        };

        private static readonly SensorsManager _sensorManager = new SensorsManager();

        public List<Reading> GetReadings()
        {
            var list = _data;
            return list;
        }

        public Reading AddReading(Reading reading)
        {
            System.Diagnostics.Debug.WriteLine(reading);
            reading.Time = DateTime.Now.ToString();
            reading.Id = _nextId++;
            reading.Validate();
            _data.Add(reading);
            if (!_sensorManager.SensorExists(reading.MacAddressSensor))
                _sensorManager.AddSensor(new Sensor() {Name = "Unassigned", MacAddress = reading.MacAddressSensor});

            return reading;
        }

        
    }
}
