using Dal.Exercise;
using Dal.Mode;
using Dal.Room;
using Dal.User;
using Microsoft.EntityFrameworkCore;

namespace Dal;

public class DataContext: DbContext
{
    public DbSet<UserDal> User { get; set; }
    public DbSet<RoomDal> Room { get; set; }
    public DbSet<ModeDal> Mode { get; set; }
    public DbSet<ExerciseDal> Exercise { get; set; }
    
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