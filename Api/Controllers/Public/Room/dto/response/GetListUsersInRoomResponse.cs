using System.ComponentModel.DataAnnotations;
using Dal.Enam;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Room.dto.response;

public class GetListUsersInRoomResponse
{
    public string Name { get; init; }
    public List<UserResponse> UserResponses { get; init; }

    public GetListUsersInRoomResponse(string name, List<UserResponse> userResponses)
    {
        Name = name;
        UserResponses = userResponses;
    }
}