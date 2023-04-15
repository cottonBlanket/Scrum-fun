using Api.Controllers.Base;
using Api.Controllers.Public.Music.dto;
using Dal;
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
      var files = new DirectoryInfo($"../Logic/Managers/User/Files/{roomId}/").GetFiles();
      // foreach (var VARIABLE in )
      // {
      //    
      // }
      return Ok();
   }


}