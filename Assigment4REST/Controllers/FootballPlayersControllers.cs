using Assigment4REST.Managers;
using Assigment4REST.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigment4REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _pManager = new FootballPlayersManager();

        // GET: api/<FootballPlayersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<FootballPlayer>> Get()
        {
            IEnumerable<FootballPlayer> data = _pManager.GetAll();
            if (data.Count() == 0) return NoContent();
            return Ok(data);
        }

        // GET api/<FootballPlayersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer? player = _pManager.GetByID(id);
            if (player == null) return NotFound("There is no such player with this id: " +id);
            return Ok(player);
        }

        // POST api/<FootballPlayersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            if (value == null) return BadRequest();
            FootballPlayer player = _pManager.Add(value);
            return Created($"api/FootballPlayers/{player.Id}", player);
        }

        // PUT api/<FootballPlayersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            if (value == null) return NotFound();
            FootballPlayer? player = _pManager.Update(id, value);
            return Ok(player);
        }

        // DELETE api/<FootballPlayersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer? player = _pManager.GetByID(id);
            if (player == null) return NotFound();
            _pManager.Delete(player.Id);
            return Ok(player);
        }
    }
}
