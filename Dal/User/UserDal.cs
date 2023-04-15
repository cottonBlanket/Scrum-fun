using Dal.Base;
using Dal.Room;

namespace Dal.User;

public class UserDal: BaseDal<Guid>
{
    public string Name { get; set; }
    
    public int RoomId { get; set; }
    
    
    public string Path { get; set; }

    public UserDal(string name, int roomId, string path)
    {
        Name = name;
        RoomId = roomId;
        Path = path;
    }

    public UserDal()
    {
        
    }
}