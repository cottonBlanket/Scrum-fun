using Api.Controllers.Base;
using Api.Controllers.Public.Pictures.dto.request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Public.Pictures;

[Route("photo")]
public class PicturesController: BasePublicController
{
    [HttpPost("send")]
    public async Task<IActionResult> SendPhoto([FromBody] SendPhotoRequest model)
    {
        return Ok();
    }
}