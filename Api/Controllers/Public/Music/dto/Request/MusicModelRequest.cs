using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Music.dto;

public class MusicModelRequest
{
    [Required]
    [JsonProperty("Id")]
    public required Guid Id { get; set; }
    [Required]
    [JsonProperty("Path")]
    public required string Path { get; set; }
    
}