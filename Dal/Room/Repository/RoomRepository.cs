using Dal;
using Dal.Base;
using Dal.Room;
using Logic.Managers.Room.Interfaces;

namespace Logic.Managers.Room;

public class RoomRepository : BaseRepository<RoomDal, Guid>, IRoomRepository
{
    public RoomRepository(DataContext context): base(context)
    {
        
    }
}