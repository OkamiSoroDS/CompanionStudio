using CompanionStudio.Data.Storage;
using CompanionStudio.Core.Identity;

namespace CompanionStudio.Tests;

public class IdentityFileStorageTests
{
    [Fact]
    public void Save_ShouldCreateIdentityFile()
    {
        var storage = new IdentityFileStorage();

        var identity = new IdentityModel
        {
            Id = "CS-000001",
            Name = "Lilith",
            Description = "Asistente personal",
            IsActive = true
        };

        storage.Save(
            new List<IdentityModel>
            {
                identity
            });

        var result = storage.Load();

        Assert.Single(result);
        Assert.Equal("Lilith", result.First().Name);
    }
}