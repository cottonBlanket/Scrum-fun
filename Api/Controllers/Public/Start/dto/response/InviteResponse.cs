using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Start.dto.response;

public class InviteResponse
{
    [Required]
    [JsonProperty("UserId")]
    public Guid UserId { get; init; }

    public InviteResponse(Guid userId)
    {
        UserId = userId;
    }
}