using Dal.Base.Interface;
using Dal.Room;

namespace Logic.Managers.Room.Interfaces;

public interface IRoomManager: IBaseRepository<RoomDal, string>
{
    public Task SplitUsers(RoomDal room);
}