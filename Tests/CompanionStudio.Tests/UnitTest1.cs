using CompanionStudio.Core.Services;

namespace CompanionStudio.Tests;

public class IdentityServiceTests
{
    [Fact]
    public void Create_ShouldReturnNewIdentity()
    {
        var service = new IdentityService();

        var identity = service.Create(
            "Lilith",
            "Asistente personal"
        );

        Assert.NotNull(identity);
        Assert.Equal("Lilith", identity.Name);
        Assert.True(identity.IsActive);
    }
}