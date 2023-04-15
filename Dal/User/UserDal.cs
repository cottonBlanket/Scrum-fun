using Dal.Base;
using Dal.Room;

namespace Dal.User;

public class UserDal: BaseDal<Guid>
{
    public string Name { get; set; }
    
    public RoomDal Room { get; set; }
    
    public string? Path { get; set; }

    public UserDal(string name, RoomDal roomId)
    {
        Name = name;
        Room = roomId;
        Path = "1";
    }

    public UserDal()
    {
        
    }
}