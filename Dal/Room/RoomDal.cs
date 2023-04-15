using System.Text;
using Dal.Base;
using Dal.Enam;
using Dal.User;

namespace Dal.Room;

public class RoomDal: BaseDal<string>
{
    public string Name { get; set; }
    public string Modes { get; set; }
    
    public int GroupCount { get; set; }
    
    public Status Status { get; set; }

    public List<UserDal> Users { get; set; }

    public RoomDal()
    {
        
    }

    public RoomDal(string name, int groupCount, string modes)
    {
        Name = name;
        GroupCount = groupCount;
        var modesArray = modes.Split(' ');
        var buider = new StringBuilder();
        buider.Append("1 2 ");
        foreach (var e in modesArray)
        {
            if (e == "Music")
            {
                buider.Append("3 4 ");
            }
            else if(e == "Quote")
            {
                buider.Append("5 6 ");
            }
        }

        buider.Append("7");
        Modes = buider.ToString();
        Status = Status.Waiting;
        Users = new List<UserDal>();
    }

    public void NextStatus()
    {
        var statuses = Modes.Split(' ').Select(int.Parse).ToList();
        var cur = statuses.IndexOf((int)Status);
        Status = (Status)statuses[cur + 1];
    }
}