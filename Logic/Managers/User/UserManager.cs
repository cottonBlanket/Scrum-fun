using Dal.User;
using Logic.Managers.Base;
using Logic.Managers.User.Interfaces;

namespace Logic.Managers.User;

public class UserManager: BaseManager<UserDal, Guid>, IUserManager
{
    public UserManager(IUserRepository repository) : base(repository)
    {
    }

    // public async Task UploadFileAsync(Guid userId, IFormFile file)
    // {
    //     var path = $"../Logic/Managers/User/Files/{userId}_{file.FileName}";
    //     using (var fileStream = new FileStream(path, FileMode.Create))
    //     {
    //         await file.CopyToAsync(fileStream);
    //     }
    //
    //     var user = await Repository.GetAsync(userId);
    //     user.Path = path;
    //     Repository.UpdateAsync(user);
    // }
}