namespace Streaming_Library;
/// <summary>
/// Represents a television series in the streaming library.
/// </summary>
public class TVSeries : VideoMedia
{
    private int _seasonCount;
    private int _episodeLengthMinutes;

    public int SeasonCount
    {
        get { return _seasonCount; }
    }

    public int EpisodeLengthMinutes
    {
        get { return _episodeLengthMinutes; }
    }

    public TVSeries(string title, int releaseYear, string resolution,
        int seasonCount, int episodeLengthMinutes)
        : base(title, releaseYear, resolution)
    {
        if (seasonCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(seasonCount),
                "Season count must be greater than zero.");
        }

        if (episodeLengthMinutes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(episodeLengthMinutes),
                "Episode length must be greater than zero.");
        }

        _seasonCount = seasonCount;
        _episodeLengthMinutes = episodeLengthMinutes;
    }

    public override string Describe()
    {
        return $"{base.Describe()} - {_seasonCount} seasons - {_episodeLengthMinutes} minute episodes";
    }

    public override string GetMediaType()
    {
        return "TV Series";
    }

    public override int GetDurationMinutes()
    {
        return _episodeLengthMinutes;
    }
}