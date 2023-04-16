using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Music.dto;

public class UserMusicRequest
{
    [Required]
    [JsonProperty("UserId")]
    public Guid UserId { get; set; }
}