namespace Basilicum.Server.Features.Parameter
{
	using AutoMapper;
	using Basilicum.Server.Domain;
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Create.Command, Parameter>()
					.ForMember(dest => dest.Id, opt => opt.Ignore());
		}
	}
}
