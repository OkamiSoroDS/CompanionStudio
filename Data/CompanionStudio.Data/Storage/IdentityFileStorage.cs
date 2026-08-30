using System.Text.Json;

using CompanionStudio.Core.Identity;


namespace CompanionStudio.Data.Storage;


public class IdentityFileStorage : IIdentityStorage
{

    private readonly string filePath;
    private readonly string settingsPath;



    public IdentityFileStorage(
        string? customPath = null)
    {

        filePath =
            customPath ??
            Path.Combine(
                "Files",
                "identities.json");



        settingsPath =
            Path.Combine(
                "Files",
                "settings.json");

    }





    public void Save(
        IEnumerable<IdentityModel> identities)
    {

        var json =
            JsonSerializer.Serialize(
                identities,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });



        Directory.CreateDirectory(
            "Files");



        using var stream =
            new FileStream(
                filePath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.Read);



        using var writer =
            new StreamWriter(stream);



        writer.Write(json);

    }





    public List<IdentityModel> Load()
    {

        if (!File.Exists(filePath))
        {
            return new List<IdentityModel>();
        }



        var json =
            File.ReadAllText(filePath);



        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<IdentityModel>();
        }



        return
            JsonSerializer.Deserialize<List<IdentityModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })
            ?? new List<IdentityModel>();

    }





    public void SaveActiveIdentity(
        string identityId)
    {

        var settings =
            new ActiveIdentitySettings
            {
                ActiveIdentityId = identityId
            };



        var json =
            JsonSerializer.Serialize(
                settings,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });



        Directory.CreateDirectory(
            "Files");



        File.WriteAllText(
            settingsPath,
            json);

    }





    public string? LoadActiveIdentity()
    {

        if (!File.Exists(settingsPath))
        {
            return null;
        }



        var json =
            File.ReadAllText(settingsPath);



        if (string.IsNullOrWhiteSpace(json))
        {
            return null;
        }



        var settings =
            JsonSerializer.Deserialize<ActiveIdentitySettings>(
                json);



        return settings?
            .ActiveIdentityId;

    }

}





public class ActiveIdentitySettings
{

    public string? ActiveIdentityId { get; set; }

}