using System.ComponentModel.DataAnnotations;
using Dal.Enam;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Room.dto.response;

public class RoomResponse
{
    public string Name { get; init; }
    public List<UserResponse> UserResponses { get; init; }

    public RoomResponse(string name, List<UserResponse> userResponses)
    {
        Name = name;
        UserResponses = userResponses;
    }
}