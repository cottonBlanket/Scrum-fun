﻿using Api.Controllers.Base;
using Api.Controllers.Public.Room.dto.response;
using AutoMapper;
using Dal.User;
using Logic.Managers.Room.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Public.Room;

[Route("room")]
public class RoomController: BasePublicController
{
    private readonly IRoomManager _roomManager;
    private readonly IMapper _mapper;

    public RoomController(IRoomManager roomManager, IMapper mapper)
    {
        _roomManager = roomManager;
        _mapper = mapper;
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

    [HttpGet("{roomId}")]
    public async Task<IActionResult> GetRoom([FromRoute] string roomId)
    {
        var room = await _roomManager.GetAsync(roomId);

        /*var user = _mapper.Map<UserDal>(new UserResponse(room.Users.));
        
        var result = new GetListUsersInRoomResponse(room.Name, )*/

        return Ok();
    }
    
    
}