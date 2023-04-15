using Api.Controllers.Base;
using Api.Controllers.Public.Start.dto.request;
using Api.Controllers.Public.Start.dto.response;
using AutoMapper;
using Dal.Group;
using Dal.Room;
using Dal.User;
using Logic.Managers.Room.Interfaces;
using Logic.Managers.User.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Public.Start;

[Route("room")]
public class StartController: BasePublicController
{
    private readonly IUserManager _userManager;
    private readonly IRoomManager _roomManager;
    private readonly IMapper _mapper;

    public StartController(IUserManager userManager, IRoomManager roomManager, IMapper mapper)
    {
        _userManager = userManager;
        _roomManager = roomManager;
        _mapper = mapper;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequest model)
    {
        var room = _mapper.Map<RoomDal>(model);
        var roomId = await _roomManager.InsertAsync(room);
        Directory.CreateDirectory($"../../../../Logic/Room/Files/{roomId}");
        var user = new UserDal(model.UserName, room, true, null, null);
        var userId = await _userManager.InsertAsync(user);
        var response = new CreateRoomResponse(roomId, userId);
        return Ok(response);
    }

    [HttpPost("invite")]
    public async Task<IActionResult> Invite([FromBody] InviteRequest model)
    {
        var room = await _roomManager.GetAsync(model.RoomId);
        var user = new UserDal(model.UserName, room, false, null, null);
        var userId = await _userManager.InsertAsync(user);
        
        return Ok(new InviteResponse(userId));
    }

    [HttpGet("exit")]
    public async Task<IActionResult> Exit([FromHeader] Guid UserId)
    {
        await _userManager.DeleteAsync(UserId);
        return Ok();
    }
}