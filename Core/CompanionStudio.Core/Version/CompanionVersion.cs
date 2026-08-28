namespace CompanionStudio.Core.Version;

public class CompanionVersion
{
    public string CreatedVersion { get; set; } = "1.0";

    public string CurrentVersion { get; set; } = "1.0";

    public DateTime CreatedAt { get; set; }

    public DateTime? LastMigration { get; set; }
}