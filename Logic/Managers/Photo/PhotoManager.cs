using Dal.Photo;
using Dal.Photo.Repository.Interface;
using Logic.Managers.Base;
using Logic.Managers.Photo.Interface;

namespace Logic.Managers.Photo;

public class PhotoManager : BaseManager<PhotoDal, Guid>, IPhotoManager
{
    public PhotoManager(IPhotoRepository repository) : base(repository)
    {
    }
}