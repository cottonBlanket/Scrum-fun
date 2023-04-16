using Dal.Base;
using Dal.Room;

namespace Dal.Photo;

public class PhotoDal: BaseDal<Guid>
{
    public string Name { get; set; }
    
    public string File { get; set; }
    
    public RoomDal Room { get; set; }

    public PhotoDal(string name, string file, RoomDal room)
    {
        Name = name;
        File = file;
        Room = room;
    }

    public PhotoDal()
    {
        
    }
}