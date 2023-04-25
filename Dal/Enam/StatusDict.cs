namespace Dal.Enam;

public static class StatusDict
{
    private static Dictionary<int, Status> StatusMap = new()
    {
        { 1, Status.Waiting },
        { 2, Status.Pictures },
        { 3, Status.Music },
        { 4, Status.MusicEnd },
        { 5, Status.Quote },
        { 6, Status.QuoteEnd },
        { 7, Status.Finish },
    };

    public static Status GetStatus(string i)
    {
        return StatusMap[int.Parse(i)];
    }
}