using Api.Controllers.Base;
using Api.Controllers.Public.Start.dto.request;
using Api.Controllers.Public.Start.dto.response;
using Dal.Room;
using Dal.User;
using Logic.Managers.Mode.Interfaces;
using Logic.Managers.Room.Interfaces;
using Logic.Managers.User.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Public.Start;

[Route("room")]
public class StartController: BasePublicController
{
    private readonly IUserManager _userManager;
    private readonly IRoomManager _roomManager;
    private readonly IModeManager _modeManager;

    public StartController(IUserManager userManager, IRoomManager roomManager, IModeManager modeManager)
    {
        _userManager = userManager;
        _roomManager = roomManager;
        _modeManager = modeManager;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequest model)
    {
        var password = _roomManager.GeneratePassword();
        var room = new RoomDal(model.Name, password);
        var modes = _modeManager.GetAll().Where(x => model.ModeNames.Contains(x.Name)).ToList();
        room.Modes = modes;
        var roomId = await _roomManager.InsertAsync(room);
        var user = new UserDal(model.UserName, roomId);
        var userId = await _userManager.InsertAsync(user);
        var uri = new Uri($"{Request.Scheme}://{Request.Host}/room/invite/{password}");
        var response = new CreateRoomResponse(room.Name, roomId, userId, uri);
        return Ok(response);
    }

    [HttpPost("invite/")]
    public async Task<IActionResult> Invite([FromBody] InviteRequest model)
    {
        var user = new UserDal(model.UserName, model.RoomId);
        var userId = await _userManager.InsertAsync(user);
        var room = _roomManager.GetAll().FirstOrDefault(x => x.Password == model.RoomId);
        if (room == null)
            return NotFound();
        var us = await _userManager.GetAsync(userId);
        
        _roomManager.UpdateAsync(room);
        return Ok(new InviteResponse(userId));
    }

    [HttpGet("modes")]
    public IActionResult GetAllModes()
    {
        return Ok(_modeManager.GetAll());
    }
}