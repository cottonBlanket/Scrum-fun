using Dal.Group;
using Dal.Room;
using Dal.User;
using Microsoft.EntityFrameworkCore;

namespace Dal;

public class DataContext: DbContext
{
    public DbSet<UserDal> User { get; set; }
    public DbSet<RoomDal> Room { get; set; }
    public DbSet<GroupDal> Group { get; set; }
    
    
    
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {

    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}