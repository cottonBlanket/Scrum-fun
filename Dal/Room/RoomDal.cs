using Dal.Base;
using Dal.Mode;
using Dal.User;

namespace Dal.Room;

public class RoomDal: BaseDal<Guid>
{
    public string Name { get; set; }
    
    public string InviteLink { get; set; }
    
    public List<ModeDal> Modes { get; set; }

    public List<UserDal> Users { get; set; }
}