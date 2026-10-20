namespace Streaming_Library;
/// <summary>
/// Compares viewing records by viewing date from newest to oldest.
/// </summary>
public class ViewingDateComparer : IComparer<ViewingRecord>
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

        return y.WatchedOn.CompareTo(x.WatchedOn);
    }
}