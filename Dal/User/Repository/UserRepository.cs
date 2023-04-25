using Dal;
using Dal.Base;
using Dal.User;
using Logic.Managers.User.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logic.Managers.User;

public class UserRepository: BaseRepository<UserDal, Guid>, IUserRepository
{
    public UserRepository(DataContext context): base(context)
    {
        
    }

    public override Task<UserDal?> GetAsync(Guid id)
    {
        return _dbSet.Include(x => x.Room).FirstOrDefaultAsync(x => x.Id == id);
    }
}