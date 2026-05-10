using hw1_Anat_Noa.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hw1_Anat_Noa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // GET: api/<GamesController>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
           
            Game game = new Game();
            return game.Read();

        }

        [HttpGet("getByName")]
        public IEnumerable<Game> Get2(string name)
        {
            Game game = new Game();
            return game.GetByName(name);

        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GamesController>
        [HttpPost]
        public bool Post([FromBody] Game game)
        {
            return game.Insert();
            
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Game game)
        {
            Game g = new Game();
            return g.UpdateGame(id, game);
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Game game = new Game();
            return game.DeleteById(id);
        }
    }
}
