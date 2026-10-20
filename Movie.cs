namespace Streaming_Library;
/// <summary>
/// Represents a movie in the streaming libbrary.
/// </summary>
public class Movie : VideoMedia, IDownloadable
{
    private int _runtimeMinutes;

    public int RuntimeMinutes
    {
        get { return _runtimeMinutes; }
    }

    public Movie(string title, int releaseYear, string resolution, int runtimeMinutes)
        : base(title, releaseYear, resolution)
    {
        if (runtimeMinutes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(runtimeMinutes),
                "Runtime must be greater than zero.");
        }

        _runtimeMinutes = runtimeMinutes;
    }

    public override string Describe()
    {
        return $"{base.Describe()} - {_runtimeMinutes} minutes";
    }

    public override string GetMediaType()
    {
        return "Movie";
    }

    public override int GetDurationMinutes()
    {
        return _runtimeMinutes;
    }

    public string DownloadInfo()
    {
        return $"{Title} is available to download as a movie.";
    }
}