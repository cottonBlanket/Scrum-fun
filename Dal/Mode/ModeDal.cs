using Dal.Base;
using Dal.Exercise;

namespace Dal.Mode;

public class ModeDal: BaseDal<Guid>
{
    public string Name { get; set; }
    
    public List<ExerciseDal> Exercises { get; set; }
}