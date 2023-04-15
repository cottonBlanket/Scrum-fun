namespace Api.Controllers.Public.Start.dto.response;

public class CreateRoomResponse
{
    public string RoomId { get; init; }
    public Guid UserId { get; init; }

    public CreateRoomResponse(string roomId, Guid userId)
    {
        RoomId = roomId;
        UserId = userId;
    }
}