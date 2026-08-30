using Microsoft.Extensions.Logging;


using CompanionStudio.App.UI.Services;
using CompanionStudio.App.UI.Components;
using CompanionStudio.App.UI.Views;


using CompanionStudio.Core.Runtime;
using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Services;
using CompanionStudio.Core.Profile;


using CompanionStudio.Data.Storage;
using CompanionStudio.Data.Services;



namespace CompanionStudio.App;



public static class MauiProgram
{

    public static MauiApp CreateMauiApp()
    {

        var builder =
            MauiApp.CreateBuilder();



        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {

                fonts.AddFont(
                    "OpenSans-Regular.ttf",
                    "OpenSansRegular");


                fonts.AddFont(
                    "OpenSans-Semibold.ttf",
                    "OpenSansSemibold");

            });





        // ==========================
        // CORE RUNTIME
        // ==========================

        builder.Services
            .AddSingleton<CompanionRuntime>();






        // ==========================
        // IDENTITY STORAGE
        // ==========================

        builder.Services
            .AddSingleton<
                IIdentityStorage,
                IdentityFileStorage>();







        // ==========================
        // PROFILE STORAGE
        // ==========================

        builder.Services
            .AddSingleton<
                IIdentityProfileStorage,
                IdentityProfileStorage>();








        // ==========================
        // CORE SERVICES
        // ==========================


        builder.Services
            .AddSingleton<IdentitySelectorService>();


        builder.Services
            .AddSingleton<CurrentIdentityService>();


        builder.Services
            .AddSingleton<LanguageService>();


        builder.Services
            .AddSingleton<IdentityService>();








        // ==========================
        // DATA SERVICES
        // ==========================


        builder.Services
            .AddSingleton<SettingsService>();








        // ==========================
        // UI SERVICES
        // ==========================


        builder.Services
            .AddSingleton<CompanionUIService>();








        // ==========================
        // UI COMPONENTS
        // ==========================


        builder.Services
            .AddTransient<IdentityCard>();


        builder.Services
            .AddTransient<DashboardPage>();


        builder.Services
            .AddTransient<SettingsPage>();







#if DEBUG

        builder.Logging.AddDebug();

#endif





        return builder.Build();

    }

}