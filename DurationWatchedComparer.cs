namespace Streaming_Library;
/// <summary>
/// Compares viewing records by minutes watched from longest to shortest.
/// </summary>
public class DurationWatchedComparer : IComparer<ViewingRecord>
{
    public int Compare(ViewingRecord? x, ViewingRecord? y)
    {
        if (x == null && y == null)
        {
            return 0;
        }

        if (x == null)
        {
            return 1;
        }

        if (y == null)
        {
            return -1;
        }

        return y.MinutesWatched.CompareTo(x.MinutesWatched);
    }
}