namespace Streaming_Library;
/// <summary>
/// Represents an audiobook in the streaming library.
/// </summary>
public class Audiobook : MediaItem, IDownloadable
{
    private string _narrator;
    private int _lengthMinutes;

    public string Narrator
    {
        get { return _narrator; }
    }

    public int LengthMinutes
    {
        get { return _lengthMinutes; }
    }

    public Audiobook(string title, int releaseYear, string narrator, int lengthMinutes)
        : base(title, releaseYear)
    {
        if (string.IsNullOrWhiteSpace(narrator))
        {
            throw new ArgumentException("Narrator cannot be empty.", nameof(narrator));
        }

        if (lengthMinutes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lengthMinutes),
                "Length must be greater than zero.");
        }

        _narrator = narrator;
        _lengthMinutes = lengthMinutes;
    }

    public override string Describe()
    {
        return $"{base.Describe()} - narrated by {_narrator} - {_lengthMinutes} minutes";
    }

    public override string GetMediaType()
    {
        return "Audiobook";
    }

    public override int GetDurationMinutes()
    {
        return _lengthMinutes;
    }

    public string DownloadInfo()
    {
        return $"{Title} is available to download as an audiobook.";
    }
}