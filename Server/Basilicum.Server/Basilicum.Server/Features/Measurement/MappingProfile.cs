namespace Basilicum.Server.Features.Measurement
{
	using AutoMapper;
	using Basilicum.Server.Domain;

	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Create.Command, Measurement>()
					.ForMember(dest => dest.Id, opt => opt.Ignore());
		}
	}
}
