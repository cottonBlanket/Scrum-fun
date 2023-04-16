using System.Data.SqlTypes;
using Dal.Group;
using Dal.Group.Repository.Interface;
using Dal.Room;
using Logic.Managers.Base;
using Logic.Managers.Group.Interface;
using Logic.Managers.Room.Interfaces;
using Logic.Managers.Static.Quote;


namespace Logic.Managers.Room;

public class RoomManager: BaseManager<RoomDal, string>, IRoomManager
{
    private readonly IGroupRepository _groupRepository;
    public RoomManager(IRoomRepository repository, IGroupRepository groupManager) : base(repository)
    {
        _groupRepository = groupManager;
    }

    public async Task SplitUsers(RoomDal room)
    {
        var rnd = new Random();
        var users = room.Users;
        var groups = new List<GroupDal>();
        for (int i = 0; i < room.GroupCount; i++)
        {
            var group = new GroupDal(Quote.Quotes[rnd.Next(Quote.Quotes.Count)]);
            var id = await _groupRepository.InsertAsync(group);
            groups.Add(group);
        }

        for (int i = 0; i < users.Count; i++)
            users[i].Group = groups[i % room.GroupCount];
    }
}