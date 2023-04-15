using Dal.Room;
using Logic.Managers.Base;
using Logic.Managers.Room.Interfaces;

namespace Logic.Managers.Room;

public class RoomManager: BaseManager<RoomDal, Guid>, IRoomManager
{
    public RoomManager(IRoomRepository repository) : base(repository)
    {
    }
}