using Api.Controllers.Internal.Modes.dto.request;
using AutoMapper;
using Dal.Mode;

namespace Api.Controllers.Internal.Modes.Mapping;

public class CreateModeProfile : Profile
{
    public CreateModeProfile()
    {
        CreateMap<CreateModeRequest, ModeDal>()
            .ForMember(dst => dst.Time, opt => opt.MapFrom(src => src.Time))
            .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
    }
    
}