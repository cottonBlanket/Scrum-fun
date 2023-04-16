using Dal.Base;
using Dal.Photo.Repository.Interface;

namespace Dal.Photo.Repository;

public class PhotoRepository : BaseRepository<PhotoDal, Guid>, IPhotoRepository
{
    public PhotoRepository(DataContext context) : base(context)
    {
    }
}