using Api.Controllers.Base;
using Api.Controllers.Public.Music.dto;
using Dal;
using Logic.Managers.User.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Public.Music;


[Route("music")]
public class MusicController : BasePublicController
{
   private IUserManager _userManager;

   public MusicController(IUserManager userManager)
   {
      _userManager = userManager;
   }
   [HttpPost("add/{userId:guid}")]
   public async Task<IActionResult> UploadFile([FromRoute]Guid userId, IFormFile file)
   {
      return Ok();
   }
   
   
}