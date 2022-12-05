using Class_Library;

namespace LåsRest.Managers
{
    public class ReadingsManager
    {
        private static int _nextId = 1;

        private static readonly List<Reading> _data = new()
        {
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 1, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 2, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 3, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 4, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 1, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 1, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 2, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 3, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 5, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 5, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 2, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 2, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 1, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 4, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 5, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 4, Time = "2022-12-05"},
            new Reading() {Id = _nextId++, MacAddressSensor = "AA-00-04-00-XX-YY", OpenedBy = 3, Time = "2022-12-05"},
        };

        public List<Reading> GetReadings()
        {
            var list = _data;
            return list;
        }
    }
}
