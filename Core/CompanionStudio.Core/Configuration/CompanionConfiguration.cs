namespace CompanionStudio.Core.Configuration;

public class CompanionConfiguration
{
    public string StoragePath { get; set; } = "Companions";

    public string DefaultLanguage { get; set; } = "es";

    public bool AutoSave { get; set; } = true;

    public bool LoggingEnabled { get; set; } = true;

    public string Version { get; set; } = "1.0";
}