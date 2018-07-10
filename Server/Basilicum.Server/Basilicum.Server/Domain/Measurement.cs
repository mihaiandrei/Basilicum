using System;

namespace Basilicum.Server.Domain
{
	public class Measurement : IEntity
	{
		public int Id { get; set; }

		public double Value { get; set; }

		public DateTime Date { get; set; }
	}
}
