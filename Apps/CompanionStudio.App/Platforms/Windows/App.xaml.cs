using Microsoft.UI.Xaml;


namespace CompanionStudio.App.WinUI;


public partial class App : MauiWinUIApplication
{

    public App()
    {

        InitializeComponent();

    }



    protected override MauiApp CreateMauiApp()
    {

        return MauiProgram.CreateMauiApp();

    }

}