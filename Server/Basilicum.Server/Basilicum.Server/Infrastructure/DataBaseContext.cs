namespace Basilicum.Server.Infrastructure
{
	using Basilicum.Server.Domain;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;

	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{ }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"]);
		//			}

		public DbSet<Measurement> Measurements { get; set; }
	}
}
