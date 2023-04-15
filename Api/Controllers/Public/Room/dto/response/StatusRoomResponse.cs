using System.ComponentModel.DataAnnotations;
using Dal.Enam;

namespace Api.Controllers.Public.Room.dto.response;

public class StatusRoomResponse
{
    [Required]
    public Status RoomStatus { get; init; }

    public StatusRoomResponse(Status roomStatus)
    {
        RoomStatus = roomStatus;
    }
}