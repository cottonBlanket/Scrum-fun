namespace Api.Controllers.Public.Pictures.dto.response;

public class PhotoResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    
    public string File { get; init; }
}