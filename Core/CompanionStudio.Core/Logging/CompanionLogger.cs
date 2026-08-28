namespace CompanionStudio.Core.Logging;

public class CompanionLogger
{
    private readonly List<string> logs;


    public CompanionLogger()
    {
        logs = new List<string>();
    }


    public void Log(
        string message)
    {
        logs.Add(
            $"{DateTime.UtcNow:o} - {message}");
    }


    public IReadOnlyList<string> GetLogs()
    {
        return logs;
    }
}