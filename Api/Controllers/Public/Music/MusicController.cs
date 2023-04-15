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
   [HttpPost("addMusic")]
   public async Task<IActionResult> AddMusic(IFormFile file, Guid userId)
   { 
      var uploadPath = $"../../../../Logic/MP3\\{userId}.mp3";
      var user = await _userManager.GetAsync(userId);

      if (user != null)
      {
         var name = file.FileName.Split("."); 
         if (name.Length != 2 || name[1] != "mp3")
         {
            return BadRequest();
         }
         
         using (var fileStream = new FileStream(uploadPath, FileMode.Create))
         {
            file.CopyTo(fileStream);
         }

         user.Path = uploadPath;
         await _userManager.UpdateAsync(user);
         return Ok();
      }

      return BadRequest();
   }

   [HttpPut("UpdateMusic")]
   public async Task<IActionResult> Update(MusicModelRequest model)
   {
      var user = await _userManager.GetAsync(model.Id);
      user.Path = model.Path;
      var id = await _userManager.UpdateAsync(user);
      return Ok(id);
   }
    
   [HttpDelete("Delete")]
   public async Task<IActionResult> Delete(Guid userId)
   {
      var user = await _userManager.GetAsync(userId);
      user.Path = "";
      await _userManager.UpdateAsync(user);
      return Ok();
   }
   
}