using CompanionStudio.App.UI.Views;


namespace CompanionStudio.App;


public partial class AppShell : Shell
{

    public AppShell()
    {

        InitializeComponent();


        Routing.RegisterRoute(
            nameof(SettingsPage),
            typeof(SettingsPage));

    }

}