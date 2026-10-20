namespace Streaming_Library;
/// <summary>
/// Manages the collection of media items in the streaming library.
/// </summary>
public class StreamingLibrary
{
    private string _name;
    private List<MediaItem> _items;

    public string Name
    {
        get { return _name; }
    }

    public int ItemCount
    {
        get { return _items.Count; }
    }

    public StreamingLibrary(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Library name cannot be empty.", nameof(name));
        }

        _name = name;
        _items = new List<MediaItem>();
    }

    public bool Add(MediaItem item)
    {
        if (item == null)
        {
            return false;
        }

        _items.Add(item);
        return true;
    }

    public string Report()
    {
        string report = $"{_name} Streaming Library\n";
        report += $"Total Items: {_items.Count}\n";

        foreach (MediaItem item in _items)
        {
            report += item.ReportLine() + "\n";
        }

        return report;
    }
}