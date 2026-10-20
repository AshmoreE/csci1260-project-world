namespace Streaming_Library;
/// <summary>
/// Represents a general media item in the streaming library.
/// </summary>
public abstract class MediaItem
{
    private string _title;
    private int _releaseYear;
    private List<ViewingRecord> _viewingRecords;

    public string Title
    {
        get { return _title; }
    }

    public int ReleaseYear
    {
        get { return _releaseYear; }
    }

    public int ViewingCount
    {
        get { return _viewingRecords.Count; }
    }

    protected MediaItem(string title, int releaseYear)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        }

        if (releaseYear <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(releaseYear),
                "Release year must be greater than zero.");
        }

        _title = title;
        _releaseYear = releaseYear;
        _viewingRecords = new List<ViewingRecord>();
    }

    public virtual string Describe()
    {
        return $"{_title} ({_releaseYear})";
    }

    public abstract string GetMediaType();

    public abstract int GetDurationMinutes();

    public string ReportLine()
    {
        return $"{GetMediaType()}: {_title} ({_releaseYear}) - {GetDurationMinutes()} minutes";
    }

    public void RecordActivity(string profileName, DateTime watchedOn, int minutesWatched)
    {
        ViewingRecord record = new ViewingRecord(
            profileName,
            watchedOn,
            minutesWatched);

        _viewingRecords.Add(record);
    }

    public List<ViewingRecord> GetViewingRecords()
    {
        return new List<ViewingRecord>(_viewingRecords);
    }
}