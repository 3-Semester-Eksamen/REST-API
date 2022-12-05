using Class_Library;
using LåsRest.CustomExceptions;
using LåsRest.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LåsRest.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private static readonly SensorsManager _manager = new();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Sensor>> GetSensors()
        {
            return _manager.GetSensors();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<Sensor> AddSensor([FromBody] Sensor sensor)
        {
            try
            {
                var addedSensor = _manager.AddSensor(sensor);
                return Created("/" + addedSensor.MacAddress, addedSensor);
            }
            catch (AlreadyExists e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
