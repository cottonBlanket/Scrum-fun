using System.Text;
using Dal.Base;
using Dal.Enam;
using Dal.Photo;
using Dal.User;
using Microsoft.Extensions.FileProviders.Physical;

namespace Dal.Room;

public class RoomDal: BaseDal<string>
{
    public string Name { get; set; }
    public string Modes { get; set; }
    
    public int GroupCount { get; set; }
    
    public Status Status { get; set; }

    public List<UserDal> Users { get; set; }
    
    public List<PhotoDal> Photos { get; set; }

    public RoomDal()
    {
        
    }

    public RoomDal(string name, int groupCount, string modes)
    {
        Id = GetRandomString();
        Name = name;
        GroupCount = groupCount;
        var modesArray = modes.Split(' ');
        var buider = new StringBuilder();
        buider.Append("1 2 ");
        foreach (var e in modesArray)
        {
            if (e == "music")
            {
                buider.Append("3 4 ");
            }
            else if(e == "quote")
            {
                buider.Append("5 6 ");
            }
        }

        buider.Append("7");
        Modes = buider.ToString();
        Status = Status.Waiting;
        Users = new List<UserDal>();
        Photos = new List<PhotoDal>();
    }

    public void NextStatus()
    {
        var statuses = Modes.Split(' ').Select(int.Parse).ToList();
        var cur = statuses.IndexOf((int)Status);
        Status = (Status)statuses[cur + 1];
    }
    
    public string GetRandomString()
    {
        var random = new Random();
        string id = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 9)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return id;
    }
}