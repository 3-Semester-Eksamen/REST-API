﻿using Class_Library;
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
        public ActionResult<IEnumerable<Sensor>> GetSensors([FromQuery] bool unassigned = false)
        {
            List<Sensor> list;
            if(unassigned) list = _manager.GetUnassignedSensors();
            else list = _manager.GetSensors();

            return Ok(list);
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

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Sensor> UpdateSensor([FromBody] Sensor updatesSensor)
        {
            try
            {
                var updatedSensor = _manager.UpdateSensorName(updatesSensor);
                return Ok(updatedSensor);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
