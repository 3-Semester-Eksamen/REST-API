using Class_Library;

namespace LåsRest.Managers;

public interface ISensorsManager
{
    List<Sensor> GetAssignedSensors();
    List<Sensor> GetUnassignedSensors();
    List<Sensor> GetAllSensors();
    Sensor AddSensor(Sensor sensor);
    Sensor UpdateSensorName(Sensor updatesSensor);
    bool SensorExists(string macAddress);
}