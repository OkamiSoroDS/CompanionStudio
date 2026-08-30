using System.Text.Json;


namespace CompanionStudio.Data.Services;


public class SettingsService
{

    private readonly string filePath;



    public SettingsService()
    {

        var folder =
            Path.Combine(
                "Files");


        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }



        filePath =
            Path.Combine(
                folder,
                "settings.json");

    }





    public AppSettings Load()
    {

        if (!File.Exists(filePath))
        {
            return new AppSettings();
        }



        var json =
            File.ReadAllText(filePath);



        return JsonSerializer.Deserialize<AppSettings>(
                json)
            ?? new AppSettings();

    }





    public void Save(
        AppSettings settings)
    {

        var json =
            JsonSerializer.Serialize(
                settings,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });



        File.WriteAllText(
            filePath,
            json);

    }

}



public class AppSettings
{

    public string Language { get; set; }
        = "es";

}