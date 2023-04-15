using Dal;
using Dal.Base;
using Dal.User;
using Logic.Managers.User.Interfaces;

namespace Logic.Managers.User;

public class UserRepository: BaseRepository<UserDal, Guid>, IUserRepository
{
    public UserRepository(DataContext context): base(context)
    {
        
    }
}