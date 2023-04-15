using Api.Controllers.Public.Start.dto.request;
using AutoMapper;
using Dal.Room;

namespace Api.Controllers.Public.Start.Mapping;

public class CreateRoomProfile : Profile
{
    public CreateRoomProfile()
    {
        CreateMap<CreateRoomRequest, RoomDal>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.Modes, opt => opt.MapFrom(src => src.Modes))
            .ForMember(dst => dst.GroupCount, opt => opt.MapFrom(src => src.GroupCount));
    }
}