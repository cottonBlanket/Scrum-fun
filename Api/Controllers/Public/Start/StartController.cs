// using Api.Controllers.Base;
// using Api.Controllers.Public.Start.dto.request;
// using Api.Controllers.Public.Start.dto.response;
// using Dal.Room;
// using Dal.User;
// using Logic.Managers.Mode.Interfaces;
// using Logic.Managers.Room.Interfaces;
// using Logic.Managers.User.Interfaces;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Api.Controllers.Public.Start;
//
// [Route("room")]
// public class StartController: BasePublicController
// {
//     private readonly IUserManager _userManager;
//     private readonly IRoomManager _roomManager;
//     private readonly IModeManager _modeManager;
//
//     public StartController(IUserManager userManager, IRoomManager roomManager, IModeManager modeManager)
//     {
//         _userManager = userManager;
//         _roomManager = roomManager;
//         _modeManager = modeManager;
//     }
//     
//     [HttpPost("create")]
//     public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequest model)
//     {
//         // var room = new RoomDal(model.Name, model.GroupCount, model.Modes);
//         // var userId = _userManager.InsertAsync(new UserDal())
//         // room.Users.Add();
//     }
//
//     [HttpPost("invite/")]
//     public async Task<IActionResult> Invite([FromBody] InviteRequest model)
//     {
//         var room = await _roomManager.GetAsync(model.RoomId);
//         var user = new UserDal(model.UserName, room);
//         var userId = await _userManager.InsertAsync(user);
//         
//         return Ok(new InviteResponse(userId));
//     }
//
//     [HttpGet("modes")]
//     public IActionResult GetAllModes()
//     {
//         return Ok(_modeManager.GetAll());
//     }
// }