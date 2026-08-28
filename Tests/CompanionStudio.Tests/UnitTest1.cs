using CompanionStudio.Core.Identity;

namespace CompanionStudio.Tests;

public class IdentityTests
{
    [Fact]
    public void CreateIdentity_ShouldGenerateIdentity()
    {
        var manager = new IdentityManager();

        var identity = manager.CreateIdentity(
            "Lilith",
            "Asistente personal"
        );

        Assert.NotNull(identity);
        Assert.Equal("Lilith", identity.Name);
        Assert.Equal("CS-000001", identity.Id);
        Assert.True(identity.IsActive);
    }
}