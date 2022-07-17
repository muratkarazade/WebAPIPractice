using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero{Id= 1, Name = "Spider Man", FirstName="Peter",LastName="Parker", Place="New York City" },
                new SuperHero{Id= 2 , Name = "Batman" , FirstName="Bruce" , LastName="Wayne" , Place="Gotham"}
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetById(int id)
        {
            var hero = heroes.Find(x => x.Id == id);
            if(hero == null)return BadRequest("Not Found Hero :(");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(x => x.Id == request.Id);

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place; 

            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heroes.Find(x=>x.Id == id);
            if (null == hero) return BadRequest("Hero not Fount");
            heroes.Remove(hero);
            return Ok(heroes);
        }


    }
}
