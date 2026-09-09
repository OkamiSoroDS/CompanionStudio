using CompanionStudio.App.UI.Models;

namespace CompanionStudio.App.UI.Services;

public class DashboardService
{
    public DashboardState GetDashboardState()
    {
        return new DashboardState
        {
            CompanionName = "No companion loaded",
            CoreStatus = "Offline",
            IdentityHash = "--",
            MemoriesLoaded = 0,
            ConnectedModel = "None"
        };
    }
}