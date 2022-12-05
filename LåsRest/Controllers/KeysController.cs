using Class_Library;
using LåsRest.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LåsRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeysController : ControllerBase
    {

        private static readonly KeysManager _manager = new();

        // GET: api/<KeysController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Key>> Get()
        {
            var keys = _manager.GetKeys();
            return Ok(keys);
        }

        // GET api/<KeysController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<KeysController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Key> Post([FromBody] Key key)
        {
            try
            {
                var createdKey = _manager.CreateKey(key);
                return Created("/" + createdKey.Id ,createdKey);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("penisPost");
                return BadRequest(e.Message);
            }
        }

        // PUT api/<KeysController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Key> Put(int id, [FromBody] Key value)
        {
            try
            {
                Key updatedKey = _manager.UpdateUser(id, value);
                return Ok(updatedKey);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("penis");
                return NoContent();
            }
        }

        // DELETE api/<KeysController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Key> Delete(int id)
        {
            try
            {
                var deletedKeyUser = _manager.DeleteUser(id);
                return Ok(deletedKeyUser);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound(e.Message);
            }
            
        }
    }
}
