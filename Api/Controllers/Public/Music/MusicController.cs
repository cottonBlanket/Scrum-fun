using Api.Controllers.Base;
using Logic.Managers.User.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Public.Music;


[Route("voice")]
public class MusicController : BasePublicController
{
   private IUserManager _userManager;

   public MusicController(IUserManager userManager)
   {
      _userManager = userManager;
   }
   [HttpPost("send/{userId:guid}")]
   public async Task<IActionResult> SendVoice([FromRoute]Guid userId, IFormFile file)
   {
      var user = await _userManager.GetAsync(userId);
      await _userManager.UploadFileAsync(userId, user.Room.Id, file);
      return Ok();
   }

   [HttpGet("record/{roomId}")]
   public async Task<IActionResult> GetRecord([FromRoute] string roomId)
   {
      var path = $"../Logic/Managers/Room/Files/{roomId}";
      var directory = new DirectoryInfo(path);
      var files = directory.GetFiles().Select(x => Path.Combine(x.DirectoryName, x.Name)).ToList();
      System.IO.File.WriteAllBytes(Path.Combine(path, "record.mp3"),
         files.SelectMany(x => System.IO.File.ReadAllBytes(x)).ToArray());
      var fileType = "application/octet-stream";
      var fileStream = new FileStream(Path.Combine(path, "record.mp3"), FileMode.Open);
      return File(fileStream, fileType, "record.mp3");
   }
}