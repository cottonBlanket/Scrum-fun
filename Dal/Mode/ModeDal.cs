using Dal.Base;
using Dal.Exercise;
using Dal.Room;

namespace Dal.Mode;

public class ModeDal: BaseDal<int>
{
    public string Name { get; set; }
    
    public int Time { get; set; }
    
    public string Description { get; set; }
    
    public List<ExerciseDal> Exercises { get; set; }
    
    public List<RoomDal> Rooms { get; set; }
}