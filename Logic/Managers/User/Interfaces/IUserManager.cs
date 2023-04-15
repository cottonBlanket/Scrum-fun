using Dal.Base.Interface;
using Dal.User;


namespace Logic.Managers.User.Interfaces;

public interface IUserManager: IBaseRepository<UserDal, Guid>
{
    Task UploadFileAsync(Guid userId, string roomId, IFormFile file);
}