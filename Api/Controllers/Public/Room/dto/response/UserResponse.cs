using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Room.dto.response;

public class UserResponse
{
    [Required] 
    [JsonProperty("Id")] 
    public Guid Id { get; init; }
    
    [Required] 
    [JsonProperty("UserName")] 
    public string UserName { get; init; }
    
    [Required] 
    [JsonProperty("isOwner")] 
    public bool isOwner { get; init; }
    
    [Required] 
    [JsonProperty("GroupCount")] 
    public int Group{ get; init; }

    public UserResponse(Guid id, string userName, bool isOwner, int group)
    {
        Id = id;
        UserName = userName;
        this.isOwner = isOwner;
        Group = group;
    }
}