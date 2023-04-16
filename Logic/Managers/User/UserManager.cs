﻿using Dal.User;
using Logic.Managers.Base;
using Logic.Managers.User.Interfaces;

namespace Logic.Managers.User;

public class UserManager: BaseManager<UserDal, Guid>, IUserManager
{
    public UserManager(IUserRepository repository) : base(repository)
    {
    }

    public async Task UploadFileAsync(Guid userId, string roomId, IFormFile file, string fileName)
    {
        var path = $"../Logic/Managers/Room/Files/{roomId}/{fileName}.mp3";
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
    }

    public void UploadBase64Async(Guid userId, string roomId, string file, string fileName)
    {
        var path = $"../Logic/Managers/Room/Files/{roomId}/{fileName}.mp3";
        var bytes = Convert.FromBase64String(file);
        File.WriteAllBytes(path, bytes);
    }
}