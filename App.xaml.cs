namespace CompanionStudio.App;

public partial class App : Application
{
    private readonly AppShell appShell;

    public App(AppShell appShell)
    {
        try
        {
            InitializeComponent();

            this.appShell = appShell;
        }
        catch (Exception ex)
        {
            File.WriteAllText(
                "app_start_error.txt",
                ex.ToString());

            throw;
        }
    }


    protected override Window CreateWindow(
        IActivationState? activationState)
    {
        try
        {
            return new Window(appShell);
        }
        catch (Exception ex)
        {
            File.WriteAllText(
                "window_error.txt",
                ex.ToString());

            throw;
        }
    }
}