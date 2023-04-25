using Dal.Photo;
using Dal.Photo.Repository.Interface;
using Dal.Room;
using Logic.Managers.Base;
using Logic.Managers.Photo.Interface;
using Logic.Managers.Room.Interfaces;

namespace Logic.Managers.Photo;

public class PhotoManager : BaseManager<PhotoDal, Guid>, IPhotoManager
{
    private readonly IRoomRepository _roomRepository;
    public PhotoManager(IPhotoRepository repository, IRoomRepository roomRepository) : base(repository)
    {
        _roomRepository = roomRepository;
    }

    public List<PhotoDal> GetAllRoomPhotos(RoomDal room)
    {
        return Repository.GetAll().Where(x => x.Room == room).ToList();
    }
}