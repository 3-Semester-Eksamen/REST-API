using Class_Library;
using LåsRest.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LåsRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingsController : ControllerBase
    {
        //Use with Database
        //private static IReadingsManager _manager = new ReadingsDbManager();
        //Use with local data
        private static IReadingsManager _manager = new ReadingsManager();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Reading>> GetReadings()
        {
            var readings = _manager.GetReadings();
            return Ok(readings);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Reading>> CreateReading([FromBody] Reading reading)
        {
            Console.WriteLine(reading);
            try
            {
                Reading createdReading = _manager.AddReading(reading);
                return Ok(createdReading);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
