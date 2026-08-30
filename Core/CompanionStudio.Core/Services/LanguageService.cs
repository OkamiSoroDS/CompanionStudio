namespace CompanionStudio.Core.Services;


public class LanguageService
{

    public string CurrentLanguage { get; private set; }
        = "es";



    public event EventHandler?
        LanguageChanged;




    public void ChangeLanguage(
        string languageCode)
    {

        if (string.IsNullOrWhiteSpace(languageCode))
            return;



        CurrentLanguage =
            languageCode;



        LanguageChanged?
            .Invoke(
                this,
                EventArgs.Empty);

    }





    public string GetLanguageName()
    {

        return CurrentLanguage switch
        {

            "es" => "Español",

            "en" => "English",

            "pt" => "Português",

            "fr" => "Français",

            "de" => "Deutsch",

            "it" => "Italiano",

            "ja" => "日本語",

            "zh" => "中文",


            _ => "Español"

        };

    }

}