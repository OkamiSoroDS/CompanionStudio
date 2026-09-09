using CompanionStudio.App.UI.Models;

namespace CompanionStudio.App.UI.Components;

public partial class RuntimeStatusCard : ContentView
{
    public RuntimeStatusCard()
    {
        InitializeComponent();
    }


    public void UpdateState(DashboardState state)
    {
        StatusLabel.Text = $"Status: {state.CoreStatus}";
        ModelLabel.Text = $"Model: {state.ConnectedModel}";
    }
}