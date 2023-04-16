using System.Data.SqlTypes;
using Dal.Group;
using Dal.Group.Repository.Interface;
using Dal.Photo;
using Dal.Room;
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