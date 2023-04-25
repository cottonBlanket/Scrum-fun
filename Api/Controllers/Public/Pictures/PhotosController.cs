using Api.Controllers.Base;
using Api.Controllers.Public.Pictures.dto.request;
using Api.Controllers.Public.Pictures.dto.response;
using AutoMapper;
using Dal.Photo;
using Logic.Managers.Photo.Interface;
using Logic.Managers.Room.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Public.Pictures;

[Route("photo")]
public class PhotosController: BasePublicController
{
    private readonly IPhotoManager _photoManager;
    private readonly IRoomManager _roomManager;
    private readonly IMapper _mapper;

    public PhotosController(IPhotoManager photoManager, IRoomManager roomManager, IMapper mapper)
    {
        _photoManager = photoManager;
        _roomManager = roomManager;
        _mapper = mapper;
    }
    
    [HttpPost("send")]
    public async Task<IActionResult> SendPhoto([FromBody] SendPhotoRequest model)
    {
        var photo = _mapper.Map<PhotoDal>(model);
        var room = await _roomManager.GetAsync(model.RoomId);
        photo.Room = room;
        var id = await _photoManager.InsertAsync(photo);
        return Ok(id);
    }

    [HttpGet("{roomId}")]
    public async Task<IActionResult> GetPhotos([FromRoute] string roomId)
    {
        var room = await _roomManager.GetAsync(roomId);
        var photos = _photoManager.GetAllRoomPhotos(room).Select(x => _mapper.Map<PhotoResponse>(x)).ToList();
        var isAll = room.Users.Count - 1 == photos.Count;
        return Ok(new RoomPhotosResponse(isAll, photos));
    }
}