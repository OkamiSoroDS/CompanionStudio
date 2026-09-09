using CompanionStudio.Core.Services;
using CompanionStudio.Core.Localization;

namespace CompanionStudio.App.UI.Views;


public partial class SettingsPage : ContentPage
{

    private readonly LanguageService languageService;

    private readonly TranslationService translationService;

    private readonly LanguagePackageManager languagePackageManager;




    public SettingsPage(
    LanguageService languageService,
    TranslationService translationService,
    LanguagePackageManager languagePackageManager)
    {

        InitializeComponent();


        this.languageService =
            languageService;


        this.translationService =
            translationService;

        this.languagePackageManager =
    languagePackageManager;


        languageService.LanguageChanged +=
            LanguageChanged;



        ApplyTranslations();



        CurrentLanguageLabel.Text =
            $"{translationService.Get("language")}: {languageService.GetLanguageName()}";
        
        LanguagePicker.SelectedItem =
    languageService.GetLanguageName();

    }


    private void LoadLanguages()
    {

        var languages =
            languagePackageManager
            .GetAvailableLanguages();


        LanguagePicker.ItemsSource =
            languages.Values.ToList();


        var current =
            languageService.CurrentLanguage;


        if (languages.TryGetValue(
            current,
            out var name))
        {

            LanguagePicker.SelectedItem =
                name;

        }

    }



    private void LanguageChanged(
        object? sender,
        EventArgs e)
    {

        MainThread.BeginInvokeOnMainThread(() =>
        {

            ApplyTranslations();


            CurrentLanguageLabel.Text =
                $"{translationService.Get("language")}: {languageService.GetLanguageName()}";

            LanguagePicker.SelectedItem =
    languageService.GetLanguageName();

        });

    }





    private void ApplyTranslations()
    {

        Title =
            translationService.Get("settings");


        SettingsTitleLabel.Text =
            translationService.Get("settings");


        LanguageTitleLabel.Text =
            translationService.Get("language");


        LanguagePicker.Title =
            translationService.Get("select_language");


        ComingSoonLabel.Text =
            translationService.Get("coming_soon");


        FutureOptionsLabel.Text =
            $"{translationService.Get("appearance")}\n" +
            $"{translationService.Get("dark_mode")}\n" +
            $"{translationService.Get("export_companions")}\n" +
            $"{translationService.Get("import_companions")}\n" +
            $"{translationService.Get("security")}\n" +
            $"{translationService.Get("backup")}";

    }





    private void LanguagePicker_SelectedIndexChanged(
        object? sender,
        EventArgs e)
    {

        var language =
            LanguagePicker.SelectedItem
            ?.ToString();



        if (language == null)
            return;



        var code =
            language switch
            {

                "Español" => "es",

                "English" => "en",

                "Português" => "pt",

                "Français" => "fr",

                "Deutsch" => "de",

                "Italiano" => "it",

                "日本語" => "ja",

                "中文" => "zh",

                "हिन्दी" => "hi",

                "العربية" => "ar",

                "বাংলা" => "bn",

                "Русский" => "ru",

                "اردو" => "ur",


                _ => "es"

            };



        languageService
            .ChangeLanguage(code);

    }





    protected override void OnDisappearing()
    {

        languageService.LanguageChanged -=
            LanguageChanged;


        base.OnDisappearing();

    }

}