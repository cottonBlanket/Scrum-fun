using Api.Controllers.Public.Pictures.dto.response;
using AutoMapper;
using Dal.Photo;

namespace Api.Controllers.Public.Pictures.mapping;

public class GetPhotoProfile: Profile
{
    public GetPhotoProfile()
    {
        CreateMap<PhotoDal, PhotoResponse>()
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.File, opt => opt.MapFrom(src => src.File));

    }
}