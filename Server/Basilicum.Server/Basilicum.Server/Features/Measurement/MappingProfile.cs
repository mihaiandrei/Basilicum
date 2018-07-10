namespace Basilicum.Server.Features.Measurement
{
	using AutoMapper;
	using Basilicum.Server.Domain;

	public class MappingProfile : Profile
	{
		protected MappingProfile()
		{
			CreateMap<Create.Command, Measurement>();
		}
	}
}
