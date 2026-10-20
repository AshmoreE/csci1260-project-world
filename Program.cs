using Streaming_Library;
/// <summary>
/// Defines the download capability for supported media items.
/// </summary>
public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== 1. Classes, UML, and Relationships ===");
        Console.WriteLine();

        StreamingLibrary library = new StreamingLibrary("Stream Central");

        Movie movie = new Movie(
            "Inception",
            2010,
            "1080p",
            148);

        TVSeries series = new TVSeries(
            "Breaking Bad",
            2008,
            "1080p",
            5,
            47);

        Audiobook audiobook = new Audiobook(
            "The Hobbit",
            1937,
            "Andy Serkis",
            655);

        library.Add(movie);
        library.Add(series);
        library.Add(audiobook);

        movie.RecordActivity(
            "Alex",
            new DateTime(2026, 10, 10, 19, 30, 0),
            60);

        movie.RecordActivity(
            "Ethan",
            new DateTime(2026, 10, 12, 20, 0, 0),
            90);

        movie.RecordActivity(
            "Alex",
            new DateTime(2026, 10, 10, 19, 30, 0),
            120);

        Console.WriteLine(library.Report());


        Console.WriteLine("=== 2. Inheritance and Abstraction ===");
        Console.WriteLine();

        Console.WriteLine(movie.Describe());
        Console.WriteLine(series.Describe());
        Console.WriteLine(audiobook.Describe());

        Console.WriteLine();

        Console.WriteLine(movie.ReportLine());
        Console.WriteLine(series.ReportLine());
        Console.WriteLine(audiobook.ReportLine());

        Console.WriteLine();


        Console.WriteLine("=== 3. Polymorphism and Interfaces ===");
        Console.WriteLine();

        List<MediaItem> mediaItems = new List<MediaItem>
        {
            movie,
            series,
            audiobook
        };

        Console.WriteLine("Polymorphic media descriptions:");

        foreach (MediaItem item in mediaItems)
        {
            Console.WriteLine(item.Describe());
        }

        Console.WriteLine();

        Console.WriteLine("Downloadable media:");

        ShowDownload(movie);
        ShowDownload(audiobook);

        Console.WriteLine();

        foreach (MediaItem item in mediaItems)
        {
            if (item is IDownloadable)
            {
                Console.WriteLine($"{item.Title} implements IDownloadable.");
            }
        }

        Console.WriteLine();


        Console.WriteLine("=== 4. Built-in Contracts and Collections ===");
        Console.WriteLine();

        List<ViewingRecord> records = movie.GetViewingRecords();

        Console.WriteLine($"Records before HashSet: {records.Count}");

        HashSet<ViewingRecord> recordSet =
            new HashSet<ViewingRecord>(records);

        Console.WriteLine($"Records after HashSet: {recordSet.Count}");

        Console.WriteLine();

        Console.WriteLine("Natural order - profile, then date:");
        records.Sort();
        PrintRecords(records);

        Console.WriteLine();

        Console.WriteLine("Viewing date order - newest to oldest:");
        records.Sort(new ViewingDateComparer());
        PrintRecords(records);

        Console.WriteLine();

        Console.WriteLine("Duration order - longest to shortest:");
        records.Sort(new DurationWatchedComparer());
        PrintRecords(records);

        Console.WriteLine();

        Console.WriteLine("=== 5. Exceptions and Files ===");
        Console.WriteLine();

        LoadStartingData();

        Console.WriteLine();

        try
        {
            Movie invalidMovie = new Movie(
                "Invalid Movie",
                2026,
                "1080p",
                -148);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Caught specific exception: {ex.Message}");
        }

        Console.WriteLine();

        string logPath = Path.Combine(
            AppContext.BaseDirectory,
            "activity.log");

        try
        {
            using (ActivityLog log = new ActivityLog(logPath))
            {
                log.Write("Started activity log.");
                log.Write("Testing disposal during an exception.");

                throw new InvalidOperationException(
                    "Deliberate exception inside using block.");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Caught log exception: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Activity log contents:");

        foreach (string line in File.ReadAllLines(logPath))
        {
            Console.WriteLine(line);
        }

        Console.WriteLine();
        Console.WriteLine("Testing Dispose twice:");

        string doubleDisposePath = Path.Combine(
            AppContext.BaseDirectory,
            "double-dispose.log");

        ActivityLog doubleDisposeLog = new ActivityLog(doubleDisposePath);

        doubleDisposeLog.Write("Testing double disposal.");
        doubleDisposeLog.Dispose();
        doubleDisposeLog.Dispose();

        Console.WriteLine("Dispose called twice without error.");
    }

    public static void ShowDownload(IDownloadable item)
    {
        Console.WriteLine(item.DownloadInfo());
    }


    public static void PrintRecords(List<ViewingRecord> records)
    {
        foreach (ViewingRecord record in records)
        {
            Console.WriteLine(
                $"{record.ProfileName} | " +
                $"{record.WatchedOn:g} | " +
                $"{record.MinutesWatched} minutes");
        }
    }

    
    public static void LoadStartingData()
    {
        string dataPath = Path.Combine(
            AppContext.BaseDirectory,
            "data.txt");

        Console.WriteLine("Loading starting data:");

        foreach (string line in File.ReadLines(dataPath))
        {
            try
            {
                string[] parts = line.Split('|');

                if (parts[0] == "Movie" && parts.Length == 5)
                {
                    Movie movie = new Movie(
                        parts[1],
                        int.Parse(parts[2]),
                        parts[3],
                        int.Parse(parts[4]));

                    Console.WriteLine($"Loaded: {movie.Describe()}");
                }
                else if (parts[0] == "TVSeries" && parts.Length == 6)
                {
                    TVSeries series = new TVSeries(
                        parts[1],
                        int.Parse(parts[2]),
                        parts[3],
                        int.Parse(parts[4]),
                        int.Parse(parts[5]));

                    Console.WriteLine($"Loaded: {series.Describe()}");
                }
                else if (parts[0] == "Audiobook" && parts.Length == 5)
                {
                    Audiobook audiobook = new Audiobook(
                        parts[1],
                        int.Parse(parts[2]),
                        parts[3],
                        int.Parse(parts[4]));

                    Console.WriteLine($"Loaded: {audiobook.Describe()}");
                }
                else
                {
                    throw new FormatException(
                        $"Invalid data line: {line}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not load line: {ex.Message}");
            }
        }
    }
} 