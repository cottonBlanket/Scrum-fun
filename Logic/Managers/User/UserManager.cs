using Dal.User;
using Logic.Managers.Base;
using Logic.Managers.User.Interfaces;

namespace Logic.Managers.User;

public class UserManager: BaseManager<UserDal, Guid>, IUserManager
{
    public UserManager(IUserRepository repository) : base(repository)
    {
    }

    public async Task UploadFileAsync(Guid userId, string roomId, IFormFile file)
    {
        var path = $"../Logic/Managers/Room/Files/{roomId}/{file.FileName}";
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
    }
}