using Dal.Base;
using Dal.User;

namespace Dal.Group;

public class GroupDal: BaseDal<int>
{
    public string FullQuote { get; set; }
    
    public List<UserDal> Users { get; set; }

    public GroupDal(string fullQuote)
    {
        FullQuote = fullQuote;
        Users = new List<UserDal>();
    }
}