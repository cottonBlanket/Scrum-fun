using Dal.Base;
using Dal.Group.Repository.Interface;

namespace Dal.Group.Repository;

public class GroupRepository : BaseRepository<GroupDal, int>, IGroupRepository
{
    public GroupRepository(DataContext context) : base(context)
    {
    }
}