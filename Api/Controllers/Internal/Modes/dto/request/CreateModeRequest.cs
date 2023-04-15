namespace Api.Controllers.Internal.Modes.dto.request;

public class CreateModeRequest
{
    public string Name { get; init; }
    public int Time { get; init; }
    public string Description { get; init; }
}