using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Models;

namespace SuperHeroes.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
		//private static readonly List<SuperHero> heroes = new List<SuperHero>
		//{
		//	new SuperHero {
		//		Id = 1,
		//		Name= "Spdier Man",
		//		FirstName= "Peter",
		//		LastName= "Parker",
		//		Place="New York City"
		//	},
		//		new SuperHero {
		//		Id = 2,
		//		Name= "Ironman",
		//		FirstName= "Tony",
		//		LastName= "Stark",
		//		Place="Long Island"
		//	}
		//};

		private readonly DataContext _context;

		public SuperHeroController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<SuperHero>>> Get()
		{
			return Ok(await _context.SuperHeroes.ToListAsync());
			//return Ok(heroes);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<SuperHero>>> Get(int id)
		{
			var hero = await _context.SuperHeroes.FindAsync(id);
			//var hero = heroes.Find(h => h.Id == id);
			if (hero == null)
				return BadRequest("Hero not found!");

			return Ok(hero);
		}

		[HttpPost]
		public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
		{
			_context.SuperHeroes.Add(hero);
			await _context.SaveChangesAsync();

			return Ok(await _context.SuperHeroes.ToListAsync());
			//heroes.Add(hero);
			//return Ok(heroes);
		}

		[HttpPut]
		public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
		{
			var dbHero = await _context.SuperHeroes.FindAsync(request.Id);
			//var hero = heroes.Find(h => h.Id == request.Id);
			if (dbHero == null)
				return BadRequest("Hero not found!");

			dbHero.Name = request.Name;
			dbHero.FirstName = request.FirstName;
			dbHero.LastName = request.LastName;
			dbHero.Place = request.Place;

			await _context.SaveChangesAsync();

			return Ok(await _context.SuperHeroes.ToListAsync());
			//return Ok(heroes);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<SuperHero>>> Delete(int id)
		{
			var dbHero = await _context.SuperHeroes.FindAsync(id);
			//var hero = heroes.Find(h => h.Id == id);
			if (dbHero == null)
				return BadRequest("Hero not found!");

			_context.SuperHeroes.Remove(dbHero);
			await _context.SaveChangesAsync();

			return Ok(await _context.SuperHeroes.ToListAsync());
			//heroes.Remove(hero);
			//return Ok(hero);
		}
	}
}
