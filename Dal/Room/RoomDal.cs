using Dal.Base;
using Dal.Mode;
using Dal.User;

namespace Dal.Room;

public class RoomDal: BaseDal<Guid>
{
    public string Name { get; set; }
    
    public int Password { get; set; }
    
    public List<ModeDal> Modes { get; set; }

    public List<UserDal> Users { get; set; }

    public RoomDal(string name, int password)
    {
        Name = name;
        Password = password;
        Modes = new List<ModeDal>();
        Users = new List<UserDal>();
    }
}