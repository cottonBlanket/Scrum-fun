using Dal.Exercise;
using Logic.Managers.Base;
using Logic.Managers.Exercise.Interfaces;

namespace Logic.Managers.Exercise;

public class ExerciseManager: BaseManager<ExerciseDal, Guid>, IExerciseManager
{
    public ExerciseManager(IExerciseRepository repository) : base(repository)
    {
    }
}