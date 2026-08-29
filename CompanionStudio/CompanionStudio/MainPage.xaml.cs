using CompanionStudio.Core.Identity;

namespace CompanionStudio;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        var service =
            new CompanionIdentityService();

        var identity =
            service.Create(
                "Lilith",
                "Primer Companion");

        DisplayAlert(
            "Companion Studio",
            $"Companion creado: {identity.Name}",
            "OK");
    }
}