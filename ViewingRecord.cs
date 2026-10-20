namespace Streaming_Library;
/// <summary>
/// Represents a record of viewing or listening activity for a media item.
/// </summary>
public class ViewingRecord : IEquatable<ViewingRecord>, IComparable<ViewingRecord>
{
    private string _profileName;
    private DateTime _watchedOn;
    private int _minutesWatched;

    public string ProfileName
    {
        get { return _profileName; }
    }

    public DateTime WatchedOn
    {
        get { return _watchedOn; }
    }

    public int MinutesWatched
    {
        get { return _minutesWatched; }
    }

    public ViewingRecord(string profileName, DateTime watchedOn, int minutesWatched)
    {
        if (string.IsNullOrWhiteSpace(profileName))
        {
            throw new ArgumentException("Profile name cannot be empty.", nameof(profileName));
        }

        if (minutesWatched <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(minutesWatched),
                "Minutes watched must be greater than zero.");
        }

        _profileName = profileName;
        _watchedOn = watchedOn;
        _minutesWatched = minutesWatched;
    }

    public bool Equals(ViewingRecord? other)
    {
        if (other == null)
        {
            return false;
        }

        return _profileName == other._profileName
            && _watchedOn == other._watchedOn;
    }

    public override bool Equals(object? obj)
    {
        return obj is ViewingRecord other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_profileName, _watchedOn);
    }

    public int CompareTo(ViewingRecord? other)
    {
        if (other == null)
        {
            return 1;
        }

        int profileComparison = string.Compare(
            _profileName,
            other._profileName,
            StringComparison.Ordinal);

        if (profileComparison != 0)
        {
            return profileComparison;
        }

        return _watchedOn.CompareTo(other._watchedOn);
    }
}