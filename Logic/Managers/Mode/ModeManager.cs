using Dal.Mode;
using Logic.Managers.Base;
using Logic.Managers.Mode.Interfaces;

namespace Logic.Managers.Mode;

public class ModeManager: BaseManager<ModeDal, int>, IModeManager
{
    public ModeManager(IModeRepository repository) : base(repository)
    {
    }
}