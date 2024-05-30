using Microsoft.EntityFrameworkCore;
using SuperHeroes.Models;

namespace SuperHeroes.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<SuperHero> SuperHeroes { get; set; }
	}
}
