namespace Api.Controllers.Public.Pictures.dto.response;

public class RoomPhotosResponse
{
    public bool IsAllPhotos { get; init; }
    
    public List<PhotoResponse> Photos { get; init; }

    public RoomPhotosResponse(bool isAllPhotos, List<PhotoResponse> photos)
    {
        IsAllPhotos = isAllPhotos;
        Photos = photos;
    }
}