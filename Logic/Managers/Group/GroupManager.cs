using Dal.Base.Interface;
using Dal.Group;
using Logic.Managers.Base;
using Microsoft.AspNetCore.SignalR;

namespace Logic.Managers.Group;

public class GroupManager : BaseManager<GroupDal, int>, IGroupManager
{
    public GroupManager(IBaseRepository<GroupDal, int> repository) : base(repository)
    {
    }

    public Task AddToGroupAsync(string connectionId, string groupName,
        CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task RemoveFromGroupAsync(string connectionId, string groupName,
        CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}