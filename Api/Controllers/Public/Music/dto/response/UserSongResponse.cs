namespace Api.Controllers.Public.Music.dto.response;

public class UserSongResponse
{
    public string SongName { get; init; }
    
    public string Text { get; init; }

    public UserSongResponse(string songName, string text)
    {
        SongName = songName;
        Text = text;
    }
}