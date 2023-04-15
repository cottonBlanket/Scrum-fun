using Dal;
using Dal.Base;
using Dal.Exercise;
using Logic.Managers.Exercise.Interfaces;

namespace Logic.Managers.Exercise;

public class ExerciseRepository: BaseRepository<ExerciseDal, Guid>, IExerciseRepository
{
    public ExerciseRepository(DataContext context): base(context)
    {
        
    }
}