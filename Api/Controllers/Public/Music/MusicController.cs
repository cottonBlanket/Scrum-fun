using Api.Controllers.Base;
using Api.Controllers.Public.Music.dto.response;
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
   [HttpPost("send")]
   public void SendVoice(IFormFile file, Guid userId)
   {
      var user = _userManager.GetAsync(userId).Result;
      _userManager.UploadFileAsync(userId, user.Room.Id, file, user.QuotePiece[0].ToString());
   }

   [HttpGet("record/{roomId}")]
   public async Task<IActionResult> GetRecord([FromRoute] string roomId)
   {
      var path = $"../Logic/Managers/Room/Files/{roomId}";
      var directory = new DirectoryInfo(path);
      var files = directory.GetFiles().OrderBy(x => int.Parse(x.Name.Split('.')[0])).Select(x => Path.Combine(x.DirectoryName, x.Name)).ToList();
      System.IO.File.WriteAllBytes(Path.Combine(path, "record.mp3"),
         files.SelectMany(x => System.IO.File.ReadAllBytes(x)).ToArray());
      var fileType = "application/octet-stream";
      var fileStream = new FileStream(Path.Combine(path, "record.mp3"), FileMode.Open);
      return File(fileStream, fileType, "record.mp3");
   }

   [HttpGet("{userId}")]
   public async Task<IActionResult> GetWords([FromRoute] Guid userId)
   {
      var user = await _userManager.GetAsync(userId);
      var song = user.QuotePiece.Split(' ');
      return Ok(new UserSongResponse(song[1], song[2]));
   }
}