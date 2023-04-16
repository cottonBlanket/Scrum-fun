using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Start.dto.request;

public class InviteRequest
{
    [Required]
    [JsonProperty("RoomId")]
    public string RoomId { get; init; }

    [Required]
    [JsonProperty("UserName")]
    public string UserName { get; init; }
}