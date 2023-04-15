using Dal.Base;
using Dal.Room;

namespace Dal.User;

public class UserDal: BaseDal<Guid>
{
    public string Name { get; set; }
    
    public RoomDal RoomId { get; set; }
}