using CompanionStudio.Core.Services;


namespace CompanionStudio.App.UI.Views;


public partial class SettingsPage : ContentPage
{

    private readonly LanguageService languageService;



    public SettingsPage(
        LanguageService languageService)
    {

        InitializeComponent();


        this.languageService =
            languageService;


        CurrentLanguageLabel.Text =
            $"Idioma actual: {languageService.GetLanguageName()}";

    }





    private void LanguagePicker_SelectedIndexChanged(
        object sender,
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


                _ => "es"

            };



        languageService
            .ChangeLanguage(code);



        CurrentLanguageLabel.Text =
            $"Idioma actual: {languageService.GetLanguageName()}";

    }

}