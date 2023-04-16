using Api.Controllers.Public.Pictures.dto.request;
using AutoMapper;
using Dal.Photo;

namespace Api.Controllers.Public.Pictures.mapping;

public class SendPhotoProfile: Profile
{
    public SendPhotoProfile()
    {
        CreateMap<SendPhotoRequest, PhotoDal>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.File, opt => opt.MapFrom(src => src.File));

    }
}