using System.Text.Json;

using CompanionStudio.Core.Profile;


namespace CompanionStudio.Data.Storage;


public class IdentityProfileStorage : IIdentityProfileStorage
{

    private readonly string profilesFolder;



    public IdentityProfileStorage()
    {

        profilesFolder =
            Path.Combine(
                "Files",
                "Profiles");



        if (!Directory.Exists(profilesFolder))
        {
            Directory.CreateDirectory(
                profilesFolder);
        }

    }





    public void Save(
        IdentityProfile profile)
    {

        if (string.IsNullOrWhiteSpace(profile.IdentityId))
        {
            throw new ArgumentException(
                "IdentityId is required");
        }



        profile.UpdatedAt =
            DateTime.UtcNow;



        var json =
            JsonSerializer.Serialize(
                profile,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });



        var path =
            GetProfilePath(
                profile.IdentityId);



        File.WriteAllText(
            path,
            json);

    }





    public IdentityProfile? Load(
        string identityId)
    {

        var path =
            GetProfilePath(
                identityId);



        if (!File.Exists(path))
        {
            return null;
        }



        var json =
            File.ReadAllText(path);



        if (string.IsNullOrWhiteSpace(json))
        {
            return null;
        }



        return
            JsonSerializer.Deserialize<IdentityProfile>(
                json);

    }





    public bool Exists(
        string identityId)
    {

        return File.Exists(
            GetProfilePath(identityId));

    }





    public void Delete(
        string identityId)
    {

        var path =
            GetProfilePath(
                identityId);



        if (File.Exists(path))
        {
            File.Delete(path);
        }

    }





    private string GetProfilePath(
        string identityId)
    {

        return Path.Combine(
            profilesFolder,
            $"{identityId}.json");

    }

}