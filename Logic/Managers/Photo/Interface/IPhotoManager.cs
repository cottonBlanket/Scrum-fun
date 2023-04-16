using Dal.Base.Interface;
using Dal.Photo;
using Dal.Room;

namespace Logic.Managers.Photo.Interface;

public interface IPhotoManager: IBaseRepository<PhotoDal, Guid>
{
    public List<PhotoDal> GetAllRoomPhotos(RoomDal room);
}