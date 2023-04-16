using Dal.Base.Interface;
using Dal.Group;
using Dal.Group.Repository.Interface;
using Logic.Managers.Base;
using Logic.Managers.Group.Interface;

namespace Logic.Managers.Group;

public class GroupManager : BaseManager<GroupDal, int>, IGroupManager
{
    public GroupManager(IGroupRepository repository) : base(repository)
    {
    }
}