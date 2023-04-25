namespace Api.Controllers.Public.Music.dto;

public class SenddRequest
{
    public Guid UserId { get; init; }
    
    public string File { get; init; }
}