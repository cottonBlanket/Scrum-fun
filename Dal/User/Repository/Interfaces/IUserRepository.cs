using Dal.Base.Interface;
using Dal.User;

namespace Logic.Managers.User.Interfaces;

public interface IUserRepository: IBaseRepository<UserDal, Guid>
{
    
}