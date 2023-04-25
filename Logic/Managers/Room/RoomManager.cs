using System.Data.SqlTypes;
using Dal.Group;
using Dal.Group.Repository.Interface;
using Dal.Photo;
using Dal.Room;
using Dal.User;
using Logic.Managers.Base;
using Logic.Managers.Group.Interface;
using Logic.Managers.Room.Interfaces;
using Logic.Managers.Static.Music;
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
        var users = room.Users;
        var groups = await CreateGroups(room);
        for (int i = 0; i < users.Count; i++)
            users[i].Group = groups[i % room.GroupCount];
        
        //разделить цитаты
    }

    private void SplitQuote(List<GroupDal> groups, List<UserDal> users)
    {
        foreach (var group in groups)
        {
            var usersInGroup = users.Where(x => x.Group == group).ToList();
            var quote = group.FullQuote.Split(' ');
            var wordsCount = quote.Length / usersInGroup.Count;
            // foreach (var u in usersInGroup)
            // {
            //     u
            // }
        }
    }

    private async Task<List<GroupDal>> CreateGroups(RoomDal room)
    {
        var groups = new List<GroupDal>();
        for (int i = 0; i < room.GroupCount; i++)
        {
            var group = new GroupDal(Quote.GetRandomQuote());
            var id = await _groupRepository.InsertAsync(group);
            groups.Add(group);
        }

        return groups;
    }

    public void SplitUserWords(RoomDal room)
    {
        var song = Songs.GetRandomSong();
        var str = song.Text.Split("\n");
        var users = room.Users;
        if (room.Users.Count > str.Length)
        {
            var count = str[0].Split(' ').Length / 2;
            var words = str.SelectMany(s => s.Split(' ')).ToList();
            foreach (var user in users)
            {
                user.QuotePiece = String.Join ("', '", words.Take(count));
                words.RemoveRange(0, count);
            }
        }
        else
        {
            for (int i = 0; i < users.Count; i++)
            {
                users[i].QuotePiece = (i + 1).ToString() + ' ' + song.Name + ' ' + str[i];
            }
        }

        room.Users = users;
        Repository.UpdateAsync(room);
    }
}