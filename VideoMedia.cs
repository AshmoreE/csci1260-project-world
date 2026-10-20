namespace Streaming_Library;
/// <summary>
/// Represents video-based media with a resolution
/// </summary>
public abstract class VideoMedia : MediaItem
{
    private string _resolution;

    public string Resolution
    {
        get { return _resolution; }
    }

    protected VideoMedia(string title, int releaseYear, string resolution)
        : base(title, releaseYear)
    {
        if (string.IsNullOrWhiteSpace(resolution))
        {
            throw new ArgumentException("Resolution cannot be empty.", nameof(resolution));
        }

        _resolution = resolution;
    }

    public override string Describe()
    {
        return $"{base.Describe()} - {_resolution}";
    }
}