namespace Basilicum.Server.Domain
{
	public class Parameter : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public double Accuracy { get; set; }
    }
}
