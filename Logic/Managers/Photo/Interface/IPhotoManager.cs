using Dal.Base.Interface;
using Dal.Photo;

namespace Logic.Managers.Photo.Interface;

public interface IPhotoManager: IBaseRepository<PhotoDal, Guid>
{
    
}