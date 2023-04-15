using Api.Controllers.Base;
using Api.Controllers.Public.Room.dto.response;
using Logic.Managers.Room.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Public.Room;

[Route("room")]
public class RoomController: BasePublicController
{
    private readonly IRoomManager _roomManager;

    public RoomController(IRoomManager roomManager)
    {
        _roomManager = roomManager;
    }
    
    [HttpGet("check/{roomId}")]
    public async Task<IActionResult> GetStatus([FromRoute] string roomId)
    {
        var room = await _roomManager.GetAsync(roomId);
        return Ok(new StatusRoomResponse(room.Status));
    }

    [HttpPatch("change/{roomId}")]
    public async Task<IActionResult> ChangeStatus([FromRoute] string roomId)
    {
        var room = await _roomManager.GetAsync(roomId);
        room.NextStatus();
        await _roomManager.UpdateAsync(room);
        return Ok();
    }
}