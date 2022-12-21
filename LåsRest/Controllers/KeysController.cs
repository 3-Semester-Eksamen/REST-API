using Class_Library;
using LåsRest.CustomExceptions;
using LåsRest.Managers;
using LåsRest.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LåsRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeysController : ControllerBase
    {
        //Use with Azure Database
        //private static readonly IKeysManager _manager = new KeysDbManager();
        //Use with localDB
        private static readonly IKeysManager _manager = new KeysManager();



        // GET: api/<KeysController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<Key>> Get()
        {
            var keys = _manager.GetKeys();
            if (keys.Count == 0) return NoContent();
            return Ok(keys);
        }

        // GET api/<KeysController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Key> Get(int id)
        {
            try
            {
                var foundKey = _manager.GetKeyById(id);
                return Ok(foundKey);
            }
            catch (BadSearch e)
            {
                return NotFound();
            }
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
                return BadRequest(e.Message);
            }
        }

        // PUT api/<KeysController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Key> Put(int id, [FromBody] Key value)
        {
            try
            {
                Key updatedKey = _manager.UpdateUser(id, value);
                return Ok(updatedKey);
            }
            catch (BadSearch e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
            catch (BadSearch e)
            {
                return NotFound(e.Message);
            }
            
        }
    }
}
