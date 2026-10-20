namespace Streaming_Library;
/// <summary>
/// Writes activity messages to a file and manages the log file resource.
/// </summary>
public class ActivityLog : IDisposable
{
    private StreamWriter _writer;
    private bool _isDisposed;

    public bool IsDisposed
    {
        get { return _isDisposed; }
    }

    public ActivityLog(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Log path cannot be empty.", nameof(path));
        }

        _writer = new StreamWriter(path);
        _isDisposed = false;

        _writer.WriteLine("LOG OPENED");
        _writer.Flush();
    }

    public void Write(string message)
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(ActivityLog));
        }

        _writer.WriteLine(message);
        _writer.Flush();
    }

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        _writer.WriteLine("LOG CLOSED");
        _writer.Dispose();
        _isDisposed = true;
    }
}