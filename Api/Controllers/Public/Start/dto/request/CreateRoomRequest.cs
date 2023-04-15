using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Start.dto.request;

public class CreateRoomRequest
{
    [Required]
    [JsonProperty("UserName")]
    public required string UserName { get; init; }
    
    [Required]
    [JsonProperty("Name")]
    public required string Name { get; init; }
    
    [Required]
    [JsonProperty("ModeNames")]
    public List<string> ModeNames { get; init; }
}