using Dal;
using Dal.Base;
using Dal.Mode;
using Logic.Managers.Mode.Interfaces;

namespace Logic.Managers.Mode;

public class ModeRepository: BaseRepository<ModeDal, int>, IModeRepository
{
    public ModeRepository(DataContext context): base(context)
    {
        
    }
}