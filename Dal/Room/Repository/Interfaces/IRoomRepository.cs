using Dal.Base.Interface;
using Dal.Photo;
using Dal.Room;

namespace Logic.Managers.Room.Interfaces;

public interface IRoomRepository : IBaseRepository<RoomDal, string>
{
    public Task<List<PhotoDal>> GetAllRoomPhotos(string roomId);
}