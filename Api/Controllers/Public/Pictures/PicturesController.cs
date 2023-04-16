using Api.Controllers.Base;
using Api.Controllers.Public.Pictures.dto.request;
using AutoMapper;
using Logic.Managers.Photo.Interface;
using Logic.Managers.Room.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Public.Pictures;

[Route("photo")]
public class PicturesController: BasePublicController
{
    private readonly IPhotoManager _photoManager;
    private readonly IRoomManager _roomManager;
    private readonly IMapper _mapper;

    public PicturesController(IPhotoManager photoManager, IRoomManager roomManager)
    {
        _photoManager = photoManager;
        _roomManager = roomManager;
    }
    
    // [HttpPost("send")]
    // public async Task<IActionResult> SendPhoto([FromBody] SendPhotoRequest model)
    // {
    //     var photo = 
    // }
}