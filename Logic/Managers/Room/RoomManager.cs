using System.Data.SqlTypes;
using Dal.Room;
using Logic.Managers.Base;
using Logic.Managers.Room.Interfaces;

namespace Logic.Managers.Room;

public class RoomManager: BaseManager<RoomDal, string>, IRoomManager
{
    public RoomManager(IRoomRepository repository) : base(repository)
    {
    }

    public string GenerateId()
    {
        var rnd = new Random();
        return rnd.Next(1000, 9999).ToString();
    }
}