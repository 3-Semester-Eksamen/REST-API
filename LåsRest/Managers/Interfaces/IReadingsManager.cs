using Class_Library;

namespace LåsRest.Managers;

public interface IReadingsManager
{
    List<Reading> GetReadings();
    Reading AddReading(Reading reading);
}