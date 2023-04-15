using Dal.User;
using Logic.Managers.Base;
using Logic.Managers.User.Interfaces;

namespace Logic.Managers.User;

public class UserManager: BaseManager<UserDal, Guid>, IUserManager
{
    public UserManager(IUserRepository repository) : base(repository)
    {
    }
}