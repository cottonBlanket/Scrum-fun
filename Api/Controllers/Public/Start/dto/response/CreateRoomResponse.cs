namespace Api.Controllers.Public.Start.dto.response;

public class CreateRoomResponse
{
    public string Name { get; init; }
    public int RoomId { get; init; }
    public Guid UserId { get; init; }
    public Uri InviteUri { get; init; }

    public CreateRoomResponse(string name, int roomId, Guid userId, Uri inviteUri)
    {
        Name = name;
        RoomId = roomId;
        UserId = userId;
        InviteUri = inviteUri;
    }
}