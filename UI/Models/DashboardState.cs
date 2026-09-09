using System;
using System.Collections.Generic;
using System.Text;
namespace CompanionStudio.App.UI.Models;

public class DashboardState
{
    public string CompanionName { get; set; } = "No loaded";

    public string CoreStatus { get; set; } = "Offline";

    public string IdentityHash { get; set; } = "--";

    public int MemoriesLoaded { get; set; } = 0;

    public string ConnectedModel { get; set; } = "None";
}