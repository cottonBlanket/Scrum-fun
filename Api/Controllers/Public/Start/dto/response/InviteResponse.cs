using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Start.dto.response;

public class InviteResponse
{
    [Required]
    [JsonProperty("UserId")]
    public Guid UserId { get; init; }
    
    [Required]
    [JsonProperty("IsOwner")]
    public bool IsOwner { get; init; }

    public InviteResponse(Guid userId, bool isOwner)
    {
        UserId = userId;
        IsOwner = isOwner;
    }
}