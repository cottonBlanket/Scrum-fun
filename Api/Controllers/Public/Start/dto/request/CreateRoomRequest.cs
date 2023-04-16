using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Start.dto.request;

public class CreateRoomRequest
{
    [Required]
    [JsonProperty("UserName")]
    public string UserName { get; init; }
    
    [Required]
    [JsonProperty("Name")]
    public string Name { get; init; }
    
    [Required]
    [JsonProperty("GroupCount")]
    public int GroupCount { get; init; }
    
    [Required]
    [JsonProperty("Modes")]
    public string Modes { get; init; }
}