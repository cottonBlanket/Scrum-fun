namespace Api.Controllers.Public.Start.dto.response;

public class CreateRoomResponse
{
    public int RoomId { get; init; }
    public Guid UserId { get; init; }

    public CreateRoomResponse(int roomId, Guid userId)
    {
        RoomId = roomId;
        UserId = userId;
    }
}