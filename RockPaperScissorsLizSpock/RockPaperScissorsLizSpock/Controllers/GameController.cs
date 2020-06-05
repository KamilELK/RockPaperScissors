using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RockPaperScissors.Services;
using RockPaperScissorsLizSpock.Services;

namespace RockPaperScissorsLizSpock.Controllers
{
    [ApiController]
    [Route("getRps")]

    public class GameController : ControllerBase
    {
        // GET: api/Game
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "bienvenu", "salut" };
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        public JObject Get(string id)
        {
            Game game = new Game();
            Statistiques stats = new Statistiques();

            switch (id)
            {
                case "0":
                    return game.Play("Rock");
                case "1":
                    return game.Play("Paper");
                case "2":
                    return game.Play("Scissors");
                case "3":
                    return game.Play("Lizard");
                case "4":
                    return game.Play("Spock");
                case "init":
                    game = new Game();
                    stats.ClearStats();
                    return JObject.Parse("init");
                default:
                    return JObject.Parse("Une erreur s'est produite");
            }
        }

        // POST: api/Game
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Game/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
