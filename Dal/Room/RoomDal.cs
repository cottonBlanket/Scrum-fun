using Dal.Base;
using Dal.Enam;
using Dal.User;

namespace Dal.Room;

public class RoomDal: BaseDal<int>
{
    public string Name { get; set; }
    public string Modes { get; set; }
    
    public int GroupCount { get; set; }
    
    public Status Status { get; set; }

    public List<UserDal> Users { get; set; }

    public RoomDal()
    {
        
    }
}