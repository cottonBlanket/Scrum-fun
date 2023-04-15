using Api.Controllers.Public.Room.dto.response;
using AutoMapper;
using Dal.User;

namespace Api.Controllers.Public.Room.Mapping;

public class UserResponseProfile : Profile
{
    public UserResponseProfile()
    {
        CreateMap<UserDal, UserResponse>()
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.isOwner, opt => opt.MapFrom(src => src.IsOwner))
            .ForMember(dst => dst.Group, opt => opt.MapFrom(src => src.Group.Id));
    }
}