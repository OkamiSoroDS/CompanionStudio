namespace CompanionStudio.Core.State;

public class CompanionState
{
    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastLoaded { get; set; }

    public string Version { get; set; } = "1.0";

    public string Status { get; set; } = "Created";
}