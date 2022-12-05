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
        private static ReadingsManager _manager = new();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Reading>> GetReadings()
        {
            var readings = _manager.GetReadings();
            return Ok(readings);
        }
    }
}
