using System.Text;
using Api.Controllers.Base;
using Api.Controllers.Public.Quotes.dto.response;
using AutoMapper;
using Logic.Managers.Group;
using Logic.Managers.Group.Interface;
using Logic.Managers.Room.Interfaces;
using Logic.Managers.User.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Public.Quotes;


[Route("quotes")]
public class QuotesController : BasePublicController
{
    private readonly IGroupManager _groupManager;
    private readonly IUserManager _userManager;
    private readonly IMapper _mapper;
    private readonly IRoomManager _roomManager;

    private List<string> ListQuotes = new List<string>()
    {
        "Сложнее всего начать действовать, все остальное зависит только от упорства.",
        "Надо любить жизнь больше, чем смысл жизни.",
        "Логика может привести Вас от пункта А к пункту Б, а воображение — куда угодно."
    };

    public QuotesController(IGroupManager groupManager, IMapper mapper, IRoomManager roomManager, IUserManager userManager)
    {
        _groupManager = groupManager;
        _userManager = userManager;
        _mapper = mapper;
        _roomManager = roomManager;
    }

    [HttpGet("allQuotes/{rootId}")]
    public async Task<IActionResult> GetAllQuotes([FromRoute] string roomId)
    {
        var room = await _roomManager.GetAsync(roomId);
        var listQuotes = room.Users.Select(x => x.Group.FullQuote).ToList();
        return Ok(new GetAllQuotesModelResponse(ListQuotes));
    }

    [HttpGet("quotePiece/{userId}")]
    public async Task<IActionResult> GetQuotePiece([FromRoute] Guid userId)
    {
        var user = await _userManager.GetAsync(userId);
        return Ok(new GetQuotePriceModelResponse(user.QuotePiece));
    }

    [HttpPost("shareQuotes/{userID}")]
    public async Task<IActionResult> ShareQuotes([FromRoute] Guid userId)
    {
        var user = await _userManager.GetAsync(userId);
        var room = await _roomManager.GetAsync(user.Room.Id);
        var quote = user.Group.FullQuote;
        var quotePiece = quote.Split(' ').ToList().Take(room.GroupCount).ToString();
        user.QuotePiece = quotePiece;
        await _userManager.UpdateAsync(user);
        return Ok();
    }


}