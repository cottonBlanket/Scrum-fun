using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Start.dto.request;

public class InviteRequest
{
    [Required]
    [JsonProperty("RoomId")]
    public required int RoomId { get; init; }
    
    [Required]
    [JsonProperty("Password")]
    public required int Password { get; init; }
    
    [Required]
    [JsonProperty("UserName")]
    public required string UserName { get; init; }
}