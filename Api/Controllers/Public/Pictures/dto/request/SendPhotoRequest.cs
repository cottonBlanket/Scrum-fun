using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Pictures.dto.request;

public class SendPhotoRequest
{
    [Required]
    [JsonProperty("RoomId")]
    public string RoomId { get; init; }
    
    [Required]
    [JsonProperty("Name")]
    public string Name { get; init; }
    
    [Required]
    [JsonProperty("File")]
    public string File { get; init; }
}