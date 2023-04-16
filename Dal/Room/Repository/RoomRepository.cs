using Dal;
using Dal.Base;
using Dal.Room;
using Logic.Managers.Room.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logic.Managers.Room;

public class RoomRepository : BaseRepository<RoomDal, string>, IRoomRepository
{
    public RoomRepository(DataContext context): base(context)
    {
        
    }

    public override Task<RoomDal?> GetAsync(string id)
    {
        return _dbSet.Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == id);
    }
}