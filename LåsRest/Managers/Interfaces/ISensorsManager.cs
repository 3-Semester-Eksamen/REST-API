using Class_Library;

namespace LåsRest.Managers;

public interface ISensorsManager
{
    List<Sensor> GetSensors();
    List<Sensor> GetUnassignedSensors();
    Sensor AddSensor(Sensor sensor);
    Sensor UpdateSensorName(Sensor updatesSensor);
    bool SensorExists(string macAddress);
}