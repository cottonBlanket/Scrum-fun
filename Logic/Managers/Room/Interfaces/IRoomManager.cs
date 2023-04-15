using Dal.Base.Interface;
using Dal.Room;

namespace Logic.Managers.Room.Interfaces;

public interface IRoomManager: IBaseRepository<RoomDal, int>
{
    public int GeneratePassword();
}