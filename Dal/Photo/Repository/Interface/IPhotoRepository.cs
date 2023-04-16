using Dal.Base.Interface;

namespace Dal.Photo.Repository.Interface;

public interface IPhotoRepository : IBaseRepository<PhotoDal, Guid>
{
    
}