namespace Basilicum.Server.Infrastructure
{
	using Basilicum.Server.Domain;
	using Microsoft.EntityFrameworkCore;

	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
		}

		public DbSet<Parameter> Parameter { get; set; }

		public DbSet<Measurement> Measurement { get; set; }
	}
}
