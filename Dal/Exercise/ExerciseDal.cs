using Dal.Base;
using Dal.Mode;

namespace Dal.Exercise;

public class ExerciseDal: BaseDal<Guid>
{
    public string Name { get; set; }
    
    public string Text { get; set; }

    public ModeDal Mode { get; set; }
}