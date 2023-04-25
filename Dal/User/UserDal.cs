using Dal.Base;
using Dal.Group;
using Dal.Room;

namespace Dal.User;

public class UserDal: BaseDal<Guid>
{
    public string Name { get; set; }
    public RoomDal Room { get; set; }
    
    public bool IsOwner  { get; set; }
    
    public GroupDal? Group { get; set; }
    
    public string? QuotePiece { get; set; }

    public UserDal(string name, RoomDal room, bool isOwner = false)
    {
        Name = name;
        Room = room;
        IsOwner = isOwner;
    }

    public UserDal()
    {
        
    }
}