namespace Basilicum.Server.Infrastructure
{
	using Basilicum.Server.Domain;
	using System.Data.Entity;
	public class DatabaseContext : DbContext
	{
		public DbSet<Measurement> Measurements { get; set; }
	}
}
