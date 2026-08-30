namespace CompanionStudio.App.UI.Models;

public class CompanionViewModel
{
    public string Name { get; set; } = "Lilith";

    public string Status { get; set; } = "Stopped";

    public string IdentityHash { get; set; } = "Pending";

    public DateTime? LastLoaded { get; set; }

    public int MemoryCount { get; set; }

    public bool IsActive { get; set; }
}