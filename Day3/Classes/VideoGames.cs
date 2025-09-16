public class VideoGames
{
    // Fields
    public string? Title;
    public int ReleaseYear;
    public int Rating;
    public int ParentalGuidance;
    public bool IsMultiplayer;

    /// <summary>
    /// Primary constructor
    /// </summary>
    public VideoGames(string title, int releaseYear, int rating, int parentGuidance, bool isMultiplayer)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Rating = rating;
        ParentalGuidance = parentGuidance;
        IsMultiplayer = isMultiplayer;
    }
}