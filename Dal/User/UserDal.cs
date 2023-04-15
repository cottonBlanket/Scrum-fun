using Dal.Base;
using Dal.Room;

namespace Dal.User;

public class UserDal: BaseDal<Guid>
{
    public string Name { get; set; }
    
    public int RoomId { get; set; }

    public UserDal()
    {
        
    }
    public UserDal(string name, int room)
    {
        Name = name;
        RoomId = room;
    }
}