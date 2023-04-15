using Dal;
using Dal.Base;
using Dal.Room;
using Logic.Managers.Room.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logic.Managers.Room;

public class RoomRepository : BaseRepository<RoomDal, int>, IRoomRepository
{
    public RoomRepository(DataContext context): base(context)
    {
        
    }

    public override Task<RoomDal?> GetAsync(int id)
    {
        return _dbSet.Include(x => x.Users)
            .Include(x => x.Modes).FirstOrDefaultAsync(x => x.Id == id);
    }
}